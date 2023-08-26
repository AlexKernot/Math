#include "PostFixProcessor.hpp"

#include "Bracket.hpp"
#include "Operation.hpp"
#include "Token.hpp"

#include <memory>

void PostFixProcessor::pushOperators(Token *current,
                                     std::queue<Token *> &returnQueue,
                                     std::stack<Token *> &tempStack) {
  while (tempStack.top()->getType() == operation) {
    Operation *thisOperation = static_cast<Operation *>(current);
    Operation *nextOperation = static_cast<Operation *>(tempStack.top());
    if (thisOperation->getPrecedence() > nextOperation->getPrecedence())
      return;
    returnQueue.push(tempStack.top());
    tempStack.pop();
  }
  returnQueue.push(current);
}

void PostFixProcessor::pushUntilBrackets(std::queue<Token *> &returnQueue,
                                         std::stack<Token *> &tempStack) {
  while (tempStack.size() != 0) {
    if (tempStack.top()->getType() == bracket &&
        static_cast<Bracket *>(tempStack.top())->getDirection() == right)
      return;
    returnQueue.push(tempStack.top());
    tempStack.pop();
  }
}

// Uses a shunting yard algorithm to transform a queue of Tokens in
// infix notation into postfix or reverse Polish notation.
std::unique_ptr<std::queue<Token *> *>
PostFixProcessor::process(std::queue<Token *> &input) {
  std::queue<Token *> *returnQueue = new std::queue<Token *>();
  std::stack<Token *> tempStack;

  while (input.size() > 0) {
    // Get the token at the front of the queue
    Token *current = input.front();
    tokenType type = current->getType();
    // Logic for each type of token
    switch (type) {
    // If the token is a number, push it to the queue.
    case number:
      returnQueue->push(current);
      break;
    // If the token is a left bracket, push it to the stack.
    // If the token is a right bracket, while a left bracket is not at
    // the top of the tempStack, push from the stack onto the queue.
    case bracket:
      if (static_cast<Bracket *>(current)->getDirection() == left) {
        tempStack.push(current);
        break;
      }
      pushUntilBrackets(*returnQueue, tempStack);
      break;
    // While the top of the stack contains an operator with a higher
    // precendence than the current operator, push operators from the
    // stack to the queue.
    // Finally, push the current operator to the queue.
    case operation:
      pushOperators(current, *returnQueue, tempStack);
      break;
      // Remove the current token from the input queue.
      input.pop();
    }
  }
  // Push everything from the temp stack onto the queue.
  while (tempStack.size() > 0) {
    returnQueue->push(tempStack.top());
    tempStack.pop();
  }
  return std::make_unique<std::queue<Token *> *>(returnQueue);
}

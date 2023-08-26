#ifndef POSTFIXPROCESSOR_H
#define POSTFIXPROCESSOR_H

#include "Token.hpp"

#include <memory>
#include <queue>
#include <stack>

class PostFixProcessor {
public:
  // Uses a shunting yard algorithm to transform a queue of Tokens in
  // infix notation into postfix or reverse Polish notation.
  static std::unique_ptr<std::queue<Token *> *>
  process(std::queue<Token *> &input);

private:
  static void pushOperators(Token *current, std::queue<Token *> &returnQueue,
                            std::stack<Token *> &tempStack);
  static void pushUntilBrackets(std::queue<Token *> &returnQueue,
                                std::stack<Token *> &tempStack);
};

#endif // POSTFIXPROCESSOR_H

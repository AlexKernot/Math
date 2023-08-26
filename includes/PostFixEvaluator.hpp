#ifndef POSTFIXEVALUATOR_HPP
#define POSTFIXEVALUATOR_HPP

#include "Token.hpp"

#include <queue>

class PostFixEvaluator {
  static Token &evaluate(std::queue<Token &> input);
};

#endif // POSTFIXEVALUATOR_HPP

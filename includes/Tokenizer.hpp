#ifndef TOKENIZER_HPP
#define TOKENIZER_HPP

#include "Token.hpp"

#include <queue>
#include <string>

class Tokenizer {
public:
  std::queue<Token *> &process(std::string);
};

#endif // TOKENIZER_HPP

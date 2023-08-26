#include "Token.hpp"

Token::Token(tokenType _type) : type(_type) {}

tokenType Token::getType(void) {
    return type;
}

void Token::setType(tokenType _type) {
    type = _type;
}
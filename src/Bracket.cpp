#include "Bracket.hpp"

#include "Token.hpp"

Bracket::Bracket(bracketDirection _direction): Token(bracket), direction(_direction) {}

bracketDirection Bracket::getDirection() {
    return direction;
}
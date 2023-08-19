#ifndef BRACKET_HPP
# define BRACKET_HPP

# include "Token.hpp"

enum bracketDirection {right, left};

class Bracket : public Token {
private:
	bracketDirection direction;
public:
	Bracket(bracketDirection _direction) : Token(bracket), direction(_direction) {}
	bracketDirection getDirection(void) {return direction;}
};

#endif // BRACKET_HPP
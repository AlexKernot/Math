#ifndef BRACKET_HPP
# define BRACKET_HPP

# include "Token.hpp"

enum bracketDirection {right, left};

class Bracket : public Token {
private:
    bracketDirection direction;
public:
    Bracket(bracketDirection _direction);
    bracketDirection getDirection(void);
};

#endif // BRACKET_HPP
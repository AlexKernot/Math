#ifndef OPERATION_HPP
# define OPERATION_HPP

# include "Token.hpp"

class Operation : public Token {
private:
    int precedence;
public:
    Operation(int _precedence) : Token(operation), precedence(_precedence) {}
    virtual Token operate(Token& a, Token& b) = 0;
    int getPrecedence() {
        return precedence;
    }
};

#endif // OPERATION_HPP
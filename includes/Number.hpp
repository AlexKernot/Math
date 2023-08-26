#ifndef NUMBER_HPP
# define NUMBER_HPP

#include "Token.hpp"

class Number : public Token {
private:
	double value;
public:
	Number(double _value);
	double getValue(void);
	void setValue(double _value);
};

#endif // NUMBER_HPP
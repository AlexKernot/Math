#include "Number.hpp"

Number::Number(double _value) : Token(number), value(_value){};

double Number::getValue(void) { return value; }

void Number::setValue(double _value) { value = _value; }
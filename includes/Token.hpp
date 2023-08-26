#ifndef TOKEN_HPP
#define TOKEN_HPP

enum tokenType { number, operation, bracket };

class Token {
private:
  tokenType type;

public:
  Token(tokenType _type);
  tokenType getType(void);
  void setType(tokenType);
};

#endif // TOKEN_HPP

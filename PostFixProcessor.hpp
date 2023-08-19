#ifndef POSTFIXPROCESSOR_H
# define POSTFIXPROCESSOR_H

# include "Token.hpp"

# include <stack>
# include <queue>

class PostFixProcessor {
	static std::queue<Token &> process(std::queue<Token &>& input);
};

#endif // POSTFIXPROCESSOR_H
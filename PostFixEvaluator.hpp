#ifndef POSTFIXEVALUATOR_HPP
# define POSTFIXEVALUATOR_HPP

# include "Token.hpp"

# include <stack>

class PostFixEvaluator {
	static Token& evaluate(std::stack<Token&> input);
};

#endif // POSTFIXEVALUATOR_HPP
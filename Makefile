NAME=math

CPP=g++
CPPFLAGS=-Wall -Wextra -Wpedantic -Wno-shadow -I./includes -g
LDFLAGS=-fsanitize=address -fsanitize=undefined

VPATH=./src
OUTPUTDIRECTORY=./bin

FILES=Number.cpp Token.cpp Bracket.cpp Console.cpp PostFixProcessor.cpp main.cpp
BIN=$(FILES:%.cpp=$(OUTPUTDIRECTORY)/%.o)

$(OUTPUTDIRECTORY)/%.o: %.cpp
	$(CPP) $(CPPFLAGS) -c $< -o $@

$(NAME): $(BIN)
	$(CPP) $(LDFLAGS) $(BIN) -o $(NAME)

.PHONY: all clean fclean re

all: $(NAME)

fclean: clean
	rm -f $(NAME)

clean:
	rm -f $(BIN)

re: fclean all

NAME=math

CC=g++
CFLAGS=-Wall -Wextra -Wpedantic -Wno-shadow -g

FILES=Number.cpp Token.cpp Bracket.cpp Console.cpp PostFixProcessor.cpp 
BIN=$(FILES:%.cpp=%.o)

%.o: %.cpp
	$(CC) $(CFLAGS) -c $< -o $@

$(NAME): $(BIN)
	$(CC) -fsanitize=address $(BIN) -o $(NAME)

all: $(NAME)
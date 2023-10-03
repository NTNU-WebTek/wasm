#########################################
# UI STUFF
#########################################

class Message:
    def __set__(self, obj, value):
        Element("message").write(value)

class Positions:
    def __get__(self, obj, objtype):
        return self.values

    def __set__(self, obj, values):
        self.values = values
        for i, value in enumerate(values, start=1):
            Element(f"pos-{i}-x").add_class("hidden")
            Element(f"pos-{i}-o").add_class("hidden")
            Element(f"pos-{i}-none").add_class("hidden")
            if value == 0:
                Element(f"pos-{i}-x").remove_class("hidden")
            elif value == 1:
                Element(f"pos-{i}-o").remove_class("hidden")
            else:
                Element(f"pos-{i}-none").remove_class("hidden")

class Loaded:
    def __set__(self, obj, value):
        if value:
            Element("tictactoe").remove_class("hidden")
        else:
            Element("ticatactoe").add_class("hidden")

def reset(e):
    game.start()

def turn(n):
    game.play_turn(n)
        
#########################################
# TICTACTOE GAME
#########################################
            
class TicTacToe:
    message = Message()
    positions = Positions()
    loaded = Loaded()

    def start(self):
        self.message = "X Turn"
        self.player = 0
        self.loaded = True
        self.positions = (None, ) * 9
        self.game_running = True

    def play_turn(self, position):
        if not self.game_running:
            return
        index = position - 1
        if self.positions[index] != None:
            self.message = "Invalid position"
            return

        new_positions = self.positions[:index] + (self.player,) + self.positions[index+1:]
        self.positions = new_positions
        if not self.check_winner():
            self.next_player()

    def next_player(self):
        player_messages = ["X Turn", "O Turn"]
        self.player = (self.player + 1) % 2
        self.message = player_messages[self.player]

    def check_winner(self):
        win_patterns = [(0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6)]
        win_messages = ["X Wins", "O Wins"]
        for first, second, third in win_patterns:
            if self.positions[first] == self.positions[second] == self.positions[third] == self.player:
                self.message = win_messages[self.player]
                self.game_running = False
                return True
        if self.check_draw():
            self.message = "Draw"
            self.game_running = False
            return True
        return False

    def check_draw(self):
        for val in self.positions:
            if val == None:
                return False
        return True

game = TicTacToe()
game.start()


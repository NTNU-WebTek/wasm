use yew::{function_component, html, use_state, AttrValue, Callback, Html, MouseEvent, Properties};


#[derive(Properties, PartialEq)]
struct SquareProps {
    value: Option<AttrValue>,
    onclick: Callback<MouseEvent, ()>,
}

#[function_component]
fn Square(SquareProps { value, onclick }: &SquareProps) -> Html {
    html! {
        <button class="square" {onclick}>
            { value.to_owned().unwrap_or_default() }
        </button>
    }
}

fn calculate_winner(squares: &[Option<AttrValue>; 9]) -> Option<&AttrValue> {
    const LINES: [[usize; 3]; 8] = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];

    for line in LINES.iter() {
        let [a, b, c] = *line;
        if squares[a] == squares[b] && squares[a] == squares[c] {
            return squares[a].as_ref();
        }
    }

    None
}

#[derive(Properties, PartialEq)]
struct BoardProps {
    squares: [Option<AttrValue>; 9],
    handle_click: Callback<usize, Callback<MouseEvent>>,
}

#[function_component]
fn Board(
    BoardProps {
        squares,
        handle_click,
    }: &BoardProps,
) -> Html {
    let render_square = {
        let squares = squares.clone();
        move |i: usize| {
            let value = &squares[i];
            let onclick = handle_click.emit(i);
            html! { <Square {value} {onclick} /> }
        }
    };

    html! {
        <div>{
            for (0..3).map(|row| {
                html! {
                    <div class="board-row">{
                        for (0..3).map(|col| render_square(row * 3 + col))
                    }</div>
                }
            })
        }</div>
    }
}

#[derive(Debug)]
struct GameState {
    pub history: Vec<Frame>,
    pub step_number: usize,
    pub x_is_next: bool,
}

impl Default for GameState {
    fn default() -> Self {
        GameState {
            history: vec![Frame::default()],
            step_number: 0,
            x_is_next: true,
        }
    }
}

#[derive(Clone, Debug)]
struct Frame {
    pub squares: [Option<AttrValue>; 9],
}

impl Default for Frame {
    fn default() -> Self {
        Frame {
            squares: [None, None, None, None, None, None, None, None, None],
        }
    }
}

#[function_component]
fn Game() -> Html {
    let state = use_state(|| GameState::default());

    let current = (*state)
        .history
        .last()
        .expect("This should not be empty ever.");
    let winner = calculate_winner(&current.squares);

    

    let handle_click = {
        let state = state.clone();

        Callback::from(move |i: usize| {
            let state = state.clone();

            Callback::from(move |_: MouseEvent| {
                let history = (*state)
                    .history
                    .get(0..(((*state).step_number) + 1))
                    .expect("This should always work")
                    .to_vec();
                let current = history.last().expect("This should never be empty").clone();
                let mut squares = current.squares.clone();

                if calculate_winner(&squares).is_some() || squares[i].is_some() {
                    return;
                }

                squares[i] = if (*state).x_is_next {
                    Some(AttrValue::Static("X"))
                } else {
                    Some(AttrValue::Static("O"))
                };

                state.set(GameState {
                    history: {
                        let mut history = history.clone();
                        history.push(Frame { squares });
                        history
                    },
                    step_number: history.len(),
                    x_is_next: !(*state).x_is_next,
                });
            })
        })
    };

    let status = match winner {
        Some(winner) => format!("Winner: {winner}"),
        None => format!(
            "Next player: {}",
            if (*state).x_is_next { "X" } else { "O" }
        ),
    };

    let squares = current.squares.clone();
    html! {
        <div class="game">
            <div class="game-board">
                <Board {squares} {handle_click}/>
            </div>
            <div class="game-info">
                <div>{ status }</div>
            </div>
        </div>
    }
}

fn main() {
    yew::Renderer::<Game>::new().render();
}
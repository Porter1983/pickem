export enum GameStates {
    Final = "Final",
    InGame = "InGame",
    SpreadNotSet = "SpreadNotSet",
    SpreadLocked = "SpreadLocked",
    Cancelled = "Cancelled"
  }

export enum GameLeaderTypes {
    Away = "Away",
    Home = "Home",
    None = "None"
}
  
export enum PickTypes {
    Away = "Away",
    Home = "Home",
    None = "None",
    Hidden = "Hidden"
}

export enum PickStates {
    Cancelled = "Cancelled",
    Losing = "Losing",
    Lost = "Lost",
    None = "None",
    Pushing = "Pushing",
    Pushed = "Pushed",
    Winning = "Winning",
    Won = "Won"
}

export enum SpreadDirections {
    None = "None",
    ToAway = "ToAway",
    ToHome = "ToHome"
}
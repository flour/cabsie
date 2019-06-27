import themes from '../themes';
import { Theme } from '@material-ui/core';
import { ThemeAction, AppActionType } from '../actions/';

export const initState = (): Theme => {
  return themes.light;
};

export const appReducer = (state: any, action: ThemeAction) => {
  if (!action) return state;
  console.log('qwe');
  switch (action.type) {
    case AppActionType.SetDarkTheme:      
      return themes.dark;
    case AppActionType.SetLightTheme:
      return themes.light;
  }
  return state;
};

import themes from '../themes';
import { Theme } from '@material-ui/core';
import { ThemeAction, AppActionType } from '../actions/app';

export const initState = (): Theme => {
  return themes.light;
};

export const appReducer = (state: any, action: ThemeAction) => {
  if (!action) return state;
  console.log('qwe');
  switch (action.type) {
    case AppActionType.SET_THEME_DARK:      
      return themes.dark;
    case AppActionType.SET_THEME_LIGHT:
      return themes.light;
  }
  return state;
};

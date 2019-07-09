import { InferValuetypes } from './common';

export const AppActionType = {
  SET_THEME_DARK: 'set.theme.dark',
  SET_THEME_LIGHT: 'set.theme.light'
}

const AppActions = {
  actionSetDarkTheme: () => ({
    type: AppActionType.SET_THEME_DARK
  }),
  actionSetLightTheme: () => ({
    type: AppActionType.SET_THEME_LIGHT
  })
};

export type ThemeAction = ReturnType<InferValuetypes<typeof AppActions>>;

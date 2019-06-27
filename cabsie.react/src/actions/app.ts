import { InferValuetypes } from './common';

export declare enum AppActionType {
  SetDarkTheme = 'set.theme.dark',
  SetLightTheme = 'set.theme.light'
}

const AppActions = {
  actionSetDarkTheme: () => ({
    type: AppActionType.SetDarkTheme
  }),
  actionSetLightTheme: () => ({
    type: AppActionType.SetLightTheme
  })
};

export type ThemeAction = ReturnType<InferValuetypes<typeof AppActions>>;

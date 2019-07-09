import { createAction } from './common';
import { ILoginParams, IRegisterParams, IAuthData } from '../types/';

const AuthActionConsts = {
  AUTH_LOGIN: 'auth.login',
  AUTH_REGISTER: 'auth.register',
  AUTH_LOGIN_FAILED: 'auth.login.failed',
  AUTH_LOGIN_SUCCESS: 'auth.login.success'
};

export const loginAction = createAction<ILoginParams>(
  AuthActionConsts.AUTH_LOGIN
);

export const registerAction = createAction<IRegisterParams>(
  AuthActionConsts.AUTH_REGISTER
);

export const loginFailedAction = createAction(
  AuthActionConsts.AUTH_LOGIN_FAILED
);

export const loginSuccessAction = createAction<IAuthData>(
  AuthActionConsts.AUTH_REGISTER
);

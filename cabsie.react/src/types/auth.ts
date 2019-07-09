export interface ILoginParams {
  username: string;
  password: string;
}

export interface IRegisterParams {
  firstname: string;
  lastname: string;
  middlename?: string;
  username: string;
  email: string;
  password: string;
}

export interface IAuthData {
  token: string;
  tokenExpirationTime: number;
  id: string;
}

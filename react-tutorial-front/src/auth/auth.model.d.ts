export interface claim {
  name: string;
  value: string;
}

export interface userCredential {
  email: string;
  password: string;
}

export interface authResponse {
  token: string;
  expiration: Date;
}

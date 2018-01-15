import * as React from "react";
import { Link, Redirect, RouteComponentProps } from 'react-router-dom';
import { RoutePaths } from '../routes';
import AuthService from '../services/Auth';

let authService = new AuthService();

export class SignIn extends React.Component<RouteComponentProps<void>, any> {
    refs: {
        username: HTMLInputElement;
        password: HTMLInputElement;
    };

    state = {
        initialLoad: true,
        error:  null
    };

    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        this.setState({ errors: null, initialLoad: false });
        authService.signIn(this.refs.username.value, this.refs.password.value).then(response => {
            if (!response.is_error) {
                this.props.history.push(RoutePaths.Home);
            } else {
                this.setState({ error: response.error_content.error_description });
            }
        });
    }

    render() {
        const search = this.props.location.search;
        const params = new URLSearchParams(search);

        let initialLoadContent = null;
        if (this.state.initialLoad) {
            if (params.get('confirmed')) {
                initialLoadContent = <div className="alert alert-success" role="alert">
                    Your email address has been successfully confirmed.
                    </div>
            }

            if (params.get('expired')) {
                initialLoadContent = <div className="alert alert-info" role="alert">
                    <strong>Sesion Expired</strong> You need to sign in again.
                    </div>
            }

            if (this.props.history.location.state && this.props.history.location.state.signedOut) {
                initialLoadContent = <div className="alert alert-info" role="alert">
                    <strong>Signed Out</strong>
                </div>
            }
        }
        return <div >
            <form  onSubmit={(e) => this.handleSubmit(e)}>
                <h2 >Please sign in</h2>
                {initialLoadContent}
                {this.state.error &&
                    <div className="alert alert-danger" role="alert">
                        {this.state.error}
                    </div>
                }
                <label htmlFor="inputEmail" className="form-control-label sr-only">Email</label>
                <input type="email" id="inputEmail" ref="username" defaultValue="user@test.com" className="form-control form-control-danger" placeholder="Email address"/>
                <label htmlFor="inputPassword" className="form-control-label sr-only">sifre</label>
                <input type="password" id="inputPassword" ref="password" defaultValue="pass123*" className="form-control" placeholder="Password" />
                <button className="btn btn-lg btn-primary btn-block" type="submit">Giris yap</button>
            </form>
            <div >
                <Link to="/home">pizzalar</Link>
            </div>
        </div>;
    }
}

export class Register extends React.Component<any, any> {
    refs: {
        email: HTMLInputElement;
        password: HTMLInputElement;
    };

    state = {
        registerComplete: false,
        errors: {} as { [key: string]: string }
    };

    handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        this.setState({ errors: {} });
        authService.register(this.refs.email.value, this.refs.password.value).then(response => {
            if (!response.is_error) {
                this.setState({ registerComplete: true })
            } else {
                this.setState({ errors: response.error_content });
            }
        });
    }

    _formGroupClass(field: string) {
        var className = "form-group ";
        if (field) {
            className += " has-danger"
        }
        return className;
    }

    render() {
        if (this.state.registerComplete) {
            return <RegisterComplete email={this.refs.email.value} />
        } else {
            return <div>
                <form  onSubmit={(e) => this.handleSubmit(e)}>
                    <h2 >Please register for access</h2>
                    {this.state.errors.general &&
                        <div className="alert alert-danger" role="alert">
                            {this.state.errors.general}
                        </div>
                    }
                    <div className={this._formGroupClass(this.state.errors.username)}>
                        <label htmlFor="inputEmail">Email address</label>
                        <input type="email" id="inputEmail" ref="email" className="form-control" placeholder="Email address" />
                        <div className="form-control-feedback">{this.state.errors.username}</div>
                    </div>
                    <div className={this._formGroupClass(this.state.errors.password)}>
                        <label htmlFor="inputPassword">Password</label>
                        <input type="password" id="inputPassword" ref="password" className="form-control" placeholder="Password" />
                        <div className="form-control-feedback">{this.state.errors.password}</div>
                    </div>
                    <button className="btn btn-lg btn-primary btn-block" type="submit">Sign up</button>
                </form>
            </div>;
        };
    }
}

interface RegisterCompleteProps {
    email: string;
}

export class RegisterComplete extends React.Component<RegisterCompleteProps, any> {
    render() {
        return <div >
            <div className="alert alert-success" role="alert">
                <strong>Success!</strong>  Your account has been created.
            </div>
            <p>
                A confirmation email has been sent to {this.props.email}. You will need to follow the provided link to confirm your email address before signing in.
            </p>
            <Link className="btn btn-lg btn-primary btn-block" role="button" to="/">Sign in</Link>
        </div>;
    }
}

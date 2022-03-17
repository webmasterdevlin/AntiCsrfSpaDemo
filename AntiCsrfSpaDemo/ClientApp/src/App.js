import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import './custom.css'
import {api} from "./api-config";

export default class App extends Component {
  static displayName = App.name;

    async onCookieRequest ()  {
        await api.get("initialcookie");
    }
    
    componentDidMount() {
        this.onCookieRequest().then()
    }
  
  
  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
      </Layout>
    );
  }
}

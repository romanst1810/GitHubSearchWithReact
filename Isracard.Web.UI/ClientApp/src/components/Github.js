import React, { Component } from 'react';
import {SearchResult} from "./SearchResult";
import {GithubApi} from "../data/GithubApi";

import axios from 'axios';

export class Github extends Component {
  displayName = Github.name

  constructor(props) {
    super(props);
    this.state = {
      value: "",
      items: [],
      loading: false
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({value: event.target.value});
  }

  handleSubmit(event) {
    event.preventDefault();
    this.setState({ loading: true });

      GithubApi.search(this.state.value)
          .then(data => {
              this.setState({ loading: false });
              this.setState({ items: data.items });
          });
  }

  render() {
    return (
        <div>
          <h1>Search repositories</h1>
          <div>
          <form onSubmit={this.handleSubmit} className="form-inline">
            <div className="form-group">
              <input className="form-control"  type="text" value={this.state.value} onChange={this.handleChange} />
            </div>
            <input className="btn btn-primary" type="submit" value="Search"/>
          </form>
          </div>
          <div>
              <SearchResult items={this.state.items} />
          </div>
        </div>
    );
  }
}

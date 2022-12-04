import React, {Component} from 'react'

export class Menu extends Component{
    static displayName = Menu.name;

    constructor(props){
        super(props);
        this.state = {products: [], loading: true};
    }

    componentDidMount(){
        this.GetMenuProductsAsync();
    }

    static BuildMenu(products){
        return (
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        products.map( product => 
                            <tr key={product.id}>
                                <td>{product.name}</td>
                                <td>{product.price}</td>
                            </tr>
                            )
                    }
                </tbody>

            </table>
        );
    }

    render(){
        let contents = this.state.loading ? <p><em>Loading ....</em></p> : Menu.BuildMenu(this.state.products);
        return (
            <div>
                {contents}
            </div>
        );
    }


    async GetMenuProductsAsync(){
        const response = await fetch('https://localhost:7059/ProductsMenu');
        const data = await response.json();
        this.setState({ products: data.products, loading: false});
    }
}
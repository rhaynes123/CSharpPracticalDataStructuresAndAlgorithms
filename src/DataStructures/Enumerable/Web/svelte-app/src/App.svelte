<script>
	let name = 'world';
	let CartItem = 1;
	let selected;
	let Cart =[];

	let items = [
		{id:1, name:'Burger', price: 12.99},
		{id:2, name:'Pizza', price: 6.99},
		{id:3, name:'Salad', price: 4.00},
	];
	let addItem = function(){
		CartItem++;
	};
	let clearItems = function(){
		CartItem =0;
	};
	let handSubmit = function(){
		submitOrder(Cart);
		console.log();
	};
	let addToCart = function(row, item){
		console.log({id:row,item:item})
		Cart.push({id:row,item:item});
	};

	async function submitOrder(cart){
		let result = await fetch("https://localhost:7278/Saveorder",{
			method: 'POST',
			headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		},
			body: JSON.stringify({cart:cart})
		});
		let json = await result.json();
		console.log(json);
	};
</script>

<h1>Hello {name}!</h1>
<form>
	{#each Array(CartItem) as _, row}
	<div>
		<select bind:value={selected} on:change="{ () => addToCart(row, selected)}">
		{#each items as item}
		<option value={item}>
			{item.name}
		</option>
		{/each}
	</select>
	</div>
	
	{/each}
	
</form>
<button on:click={addItem}>
	 Add More
</button>
<button type=submit on:click={handSubmit}>
	Place Order
</button>
<button on:click={clearItems}>
	Clear All
</button>
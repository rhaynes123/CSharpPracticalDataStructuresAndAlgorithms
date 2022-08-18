<script>
	let name = 'world';
	let CartItem = 1;
	let selected;
	let Cart =[];

	let items = [
		{id:1,Name:'Burger', Price: 12.99},
		{id:2, Name:'Pizza', Price: 6.99},
		{id:3, Name:'Salad', Price: 4.00},
	];
	let addItem = function(){
		CartItem++;
	};
	let clearItems = function(){
		CartItem =0;
	};
	let handSubmit = function(){
		console.log();
	};
	let addToCart = function(row, item){
		console.log({id:row,Name:item})
		Cart.Push({id:row,Name:item});
	};
</script>

<h1>Hello {name}!</h1>
<form>
	{#each Array(CartItem) as _, row}
	<div>
		<select bind:value={selected} on:change="{ () => addToCart(row, selected)}">
		{#each items as item}
		<option value={item}>
			{item.Name}
		</option>
		{/each}
	</select>
	</div>
	
	{/each}
	
</form>
<button on:click={addItem}>
	Add Item 
</button>
<button type=submit>
	Submit Order
</button>
<button on:click={clearItems}>
	Clear All
</button>
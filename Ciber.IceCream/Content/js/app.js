App = Ember.Application.create();

App.Router.map(function() {
  this.resource('buyIceCream', { path: '/' });
  this.resource('fillFreezer', function(){
  	this.resource('addBrand');
  });
});


App.BuyIceCreamRoute = Ember.Route.extend({
  model: function() {
    return [
		{
			id: 1,
			title: 'Krone-is Jordbær',
			image: "images/is_1.jpg",
			price: 8
		},
		{
			id: 2,
			title: 'Lollipop',
			image: "images/is_2.jpg",
			price: 3
		},
		{
			id: 3,
			title: 'Snickers is',
			image: "images/is_3.jpg",
			price: 9
		}
    ];
  }
});
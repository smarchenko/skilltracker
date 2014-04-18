require.config({
  paths: {
    jquery: 'libs/jquery/jquery-min.js',
    underscore: 'libs/underscore/underscore-min.js',
    backbone: 'libs/backbone/backbone-min.js',
  }

});

require(['views/app'], function (AppView) {
  var app_view = new AppView;
});

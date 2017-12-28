$.fn.serializeObject = function()
{
	var o = {};
	var a = this.serializeArray();
	$.each(a, function() {
		if (o[this.name] !== undefined) {
			if (!o[this.name].push) {
				o[this.name] = [o[this.name]];
			}
			o[this.name].push(this.value || '');
		} else {
			o[this.name] = this.value || '';
		}
	});
	return o;
};

function getFormData(){
	return JSON.stringify($('form').serializeObject());
}

function bindData(){
	var dataFromCSharp = $("#cs-js-buffer").text();	
	var source = $("#some-template").html(); 
	var template = Handlebars.compile(source); 
	
	Handlebars.registerHelper('bindTagContent', function(tags, tagCode) {
        for(var i=0, j=tags.length; i<j; i++) {
          if(tags[i].TagCode.trim() === tagCode) 
            return new Handlebars.SafeString(
            tags[i].TagContent.replace(/(\r\n|\n|\r)/gm, '<br>')
            );
        }     
        return "";
      });
	  
	Handlebars.registerHelper('ifCond', function (v1, operator, v2, options) {
		switch (operator) {
			case '==':
				return (v1 == v2) ? options.fn(this) : options.inverse(this);
			case '===':
				return (v1 === v2) ? options.fn(this) : options.inverse(this);
			case '!==':
				return (v1 !== v2) ? options.fn(this) : options.inverse(this);
			case '<':
				return (v1 < v2) ? options.fn(this) : options.inverse(this);
			case '<=':
				return (v1 <= v2) ? options.fn(this) : options.inverse(this);
			case '>':
				return (v1 > v2) ? options.fn(this) : options.inverse(this);
			case '>=':
				return (v1 >= v2) ? options.fn(this) : options.inverse(this);
			case '&&':
				return (v1 && v2) ? options.fn(this) : options.inverse(this);
			case '||':
				return (v1 || v2) ? options.fn(this) : options.inverse(this);
			default:
				return options.inverse(this);
		}
	});
	
	$('body').append(template(JSON.parse(dataFromCSharp)));
}

function bindTemplateData(){
	
	Handlebars.registerHelper("math", function(lvalue, operator, rvalue, options) {
    lvalue = parseFloat(lvalue);
    rvalue = parseFloat(rvalue);
        
		return {
			"+": lvalue + rvalue,
			"-": lvalue - rvalue,
			"*": lvalue * rvalue,
			"/": lvalue / rvalue,
			"%": lvalue % rvalue
		}[operator];
	});

	var rendered = Handlebars.compile(
		'{{#each values}}' + 
		'i={{@index}}: ' +
		'i+1 = {{math @index "+" 1}}, ' + 
		'i-0.5 = {{math @index "+" "-0.5"}}, ' + 
		'i/2 = {{math @index "*" 2}}, ' + 
		'i%2 = {{math @index "%" 2}}, ' + 
		'i*i = {{math @index "*" @index}}\n' +
		'{{/each}}'
	)({
		values : [ 'a', 'b', 'c', 'd', 'e' ]
	});
	
	
	var dynamicData = JSON.parse($("#cs-js-buffer").text());	
	var staticData = JSON.parse($("#cs-js-buffer-static").text());				
	for (var prop in dynamicData) {
    if (!staticData.hasOwnProperty(prop)) {
        staticData[prop] = dynamicData[prop];
    }
	}
	var source = $("#some-template").html(); 
	var template = Handlebars.compile(source); 
	$('#data-template').html(template(staticData));
	
	runDocumentReady();
}

function getDocumentHtml() {
	try {
		$("#some-template").remove();
	} catch (e){}
	return document.documentElement.outerHTML;	
}

function bindFormData(){
	var datafromcsharp = $("#cs-js-buffer").text();	
	var source = $(".wrapper").html(); 
	var template = handlebars.compile(source); 
	$(".wrapper").empty();
	$(".wrapper").html(template(jQuery.parseJSON(dataFromCSharp)));
}

function runDatePicker(){
		var list = document.getElementsByClassName('date-picker');
		for(var i =0; i< list.length;i++){
			new Pikaday({ field: document.getElementsByClassName('date-picker')[i] });	
		} 		
}

function bindHtml(target, oldVal) {	
		$('#' + target).val(JSON.stringify(oldVal));
		var html = '';
		for (var i in oldVal) {
		  if(i > 0) html += '&nbsp;/&nbsp;';
		  html += ('<span>' + oldVal[i] + '<a href="javascript:void(0);" value="' + oldVal[i] + '">(x)</a></span>');
		}
		$('mark[source=' + target+ ']').html(html);		
		
		$('a', $('mark[source=' + target + ']')).click(function(){
			var currentVal = []; 
			try {
				currentVal = JSON.parse($('#' + target).val());
			} catch(e) {}
			var index = currentVal.indexOf($(this).attr('value'));
			if (index > -1) {
		    currentVal.splice(index, 1);
			}
			bindHtml(target, currentVal)
		});
}

function bindRadioGroup($elm) {	
	var name = $elm.attr('name');
	var val = $elm.val();	
	$('select[group=' + name + ']').each(function(){
		//$(this).attr('disabled', $(this).attr('group-value') !== val);			
		if($(this).attr('group-value') !== val){				
			$(this).attr('disabled', true);							
		} else {
			$(this).removeAttr('disabled');
		}
	});	
}

function bindCheckboxGroup($elm) {
	var name = $elm.attr('name');    
	var val = $elm.is(':checked');  
	$('[group="' + name + '"]').each(function(){   
		console.log(name);
		 
		if(val) $(this).removeAttr('disabled');
		else $(this).attr('disabled', true);  
				
		var groupRadioTextbox = $(this).attr('group-radio-textbox');
		var groupRadioChecked = $(this).is(':checked');
		if(groupRadioChecked && val){
			$('[group-radio-textbox="' + groupRadioTextbox + '"][type=text]').removeAttr('disabled');			
		}else{	
			$('[group-radio-textbox="' + groupRadioTextbox + '"][type=text]').attr('disabled', true);		
		} 
	}); 
}
	
function runDocumentReady(){
	runDatePicker();
	
	try {
		initKendoCalendar();
	} catch (e){}
	
	$('input[type=radio]').click(function() {
		bindRadioGroup($(this));
	});
	
	$('input[type=radio]:checked').each(function() {
		bindRadioGroup($(this));
	});
	
	$('input[type=checkbox]').click(function(){
			bindCheckboxGroup($(this));
	});
	$('input[type=checkbox]').each(function(){
			bindCheckboxGroup($(this));
	});
	
	var listRadio = $('input[type=radio]');
	for(var i =0; i<listRadio.length; i++){
		var radioItem = listRadio[i];
		if(radioItem.checked){
			var elm = radioItem;
			var name = $(elm).attr('name');
			var group = $(elm).attr('group');
			var textBoxChecked = $('input[name='+ group +']').is(':checked');
			if(textBoxChecked){
				$('input[groupTextBox=' + name + ']').removeAttr('disabled');
			}
		}		
	}
	
	$('input[type=radio]').click(function() {
		var elm = this;
		var name = $(elm).attr('name');
		var val = $(elm).val(); 
		$('input[groupTextBox=' + name + ']').each(function(){
			if($(this).attr('group-value') !== val){    
				$(this).attr('disabled', true);       
			} else {
				$(this).removeAttr('disabled');
			}
		}); 
	});
	
	$('button[target]').click(function(){
		var target = $(this).attr('target')
		var val = $('#' + target + '-source').val();		
		if(val && val.trim().length > 0) {
			var self = $('#' + target);
			var oldVal = []; 
			try {
				oldVal = JSON.parse($(self).val());
			} catch(e) {}
			if(oldVal.indexOf(val) == -1) {
				oldVal.push(val);
				bindHtml(target, oldVal);
			}						
		}
	});		
	$('button[target]').each(function(){
			var target = $(this).attr('target')		
			var oldVal = []; 
			console.log($('#' + target).val());
			try {
				oldVal = JSON.parse($('#' + target).val());
			} catch(e) {}					
			bindHtml(target, oldVal);
	});
}

$(function() {
	
	Handlebars.registerHelper("arrayFormat", function (label, value, suffix) {
		var r = "";
			try{
				var azzay = JSON.parse(value);
				for(var i in azzay) {
					if(i == 0) r = label;
					if(i > 0) r += ", ";
					
					// Convert DateStamp to DateString
					var dateItem = new Date(azzay[i]);
					if(dateItem+""  !== "Invalid Date"){
						var year = dateItem.getUTCFullYear();
						
						var date = dateItem.getDate();
						if(date<10) date = "0"+date;
						
						var month = dateItem.getMonth()+1;
						if(month<10) month = "0"+month;
						
						var theDate = year+"/"+month+"/"+date;
						r += theDate;
						continue;
					}
					
					r += azzay[i];
				}
				if(r.length > 0) r += suffix;
			}catch(e){}
			return r;
	});					
	Handlebars.registerHelper("getSex", function (value) {
		if ( value === "M" ) {
		   return "男性"
		} else {
		   return "女性";
		}
	});
	Handlebars.registerHelper("formatCurrency", function (value) {
		var n = value.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1.");
		return n;
	});
	 Handlebars.registerHelper("formatCurrencyJP", function (value) {
			var n = value.replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
			return n;
		});
	Handlebars.registerHelper("setChecked", function (value, currentValue) {
		if ( value === currentValue ) {
		   return "checked"
		} else {
		   return "";
		}
	 });
	
	Handlebars.registerHelper('select', function( value, options ){
        var $el = $('<select />').html( options.fn(this) );
        $el.find('[value="' + value + '"]').attr({'selected':'selected'});
        return $el.html();
    });           
    
	var source = $("#some-template").html(); 
	var template = Handlebars.compile(source); 	
	$('#data-template').html(template({}));
	
	runDocumentReady();		
});

//----https://sofiamedix.atlassian.net/browse/MED-15410
function bindDrugInHospitalTemplateData(){	
	var dataFromCSharp = JSON.parse($("#cs-js-buffer-in").text());
	var source = $("#template-in-hospital").html(); 
	var template = Handlebars.compile(source); 
	$('body').append(template(dataFromCSharp));
}

function bindDrugOutHospitalTemplateData(){
	var dataFromCSharp = JSON.parse($("#cs-js-buffer-out").text());
	var source = $("#template-out-hospital").html(); 
	var template = Handlebars.compile(source); 
	$('body').append(template(dataFromCSharp));
}

function insertPageBreak(){
	var iDiv = document.createElement('div');
	//iDiv.id = 'page-break';
	//iDiv.className = 'page-break';
	iDiv.setAttribute('style', 'page-break-after:always');
	document.getElementsByTagName('body')[0].appendChild(iDiv);
}

Handlebars.registerHelper('getNalsuStr', function (nalsu, donbokYn) {
	if (nalsu == '0') return '';
	return (donbokYn == 'Y') ? '回分' : '日分';	
});
Handlebars.registerHelper('getSerialV', function (dataGubun, serialV) {
	switch(dataGubun)
	{
		case 'A':
			return serialV;
			break;
		case 'C':
			return 'コメント';
			break;
		default:
			return '';
			break;
	}
});
Handlebars.registerHelper('ifCond', function (v1, operator, v2, options) {

    switch (operator) {
        case '==':
            return (v1 == v2) ? options.fn(this) : options.inverse(this);
        case '===':
            return (v1 === v2) ? options.fn(this) : options.inverse(this);
        case '!=':
            return (v1 != v2) ? options.fn(this) : options.inverse(this);
        case '!==':
            return (v1 !== v2) ? options.fn(this) : options.inverse(this);
        case '<':
            return (v1 < v2) ? options.fn(this) : options.inverse(this);
        case '<=':
            return (v1 <= v2) ? options.fn(this) : options.inverse(this);
        case '>':
            return (v1 > v2) ? options.fn(this) : options.inverse(this);
        case '>=':
            return (v1 >= v2) ? options.fn(this) : options.inverse(this);
        case '&&':
            return (v1 && v2) ? options.fn(this) : options.inverse(this);
        case '||':
            return (v1 || v2) ? options.fn(this) : options.inverse(this);
        default:
            return options.inverse(this);
    }
});
// Handlebars.registerHelper("getSex", function (sex, langMode) {
	// var retVal = '';
	// switch (langMode.toUpperCase())
	// {
		// case 'JA':
			// retVal = sex == "M" ? "男性" : "女性";
			// break;
		// case 'VI':
			// retVal = sex == "M" ? "Nam" : "Nữ";
			// break;
		// case 'EN':
			// retVal = sex == "M" ? "Male" : "Female";
			// break;
		// default:
			// break;
	// }
	
	// return retVal;
// });
//-----------------------------------------------------
/**
 * Created by quangbv on 02/03/2016.
 */
(function () {
    'use strict';

    angular
        .module('app')
        .directive('mindMap', function (gettextCatalog) {
            return {
                link: function(scope, element) {
                    //console.log("directive________________mindMap");
                    /*var eleW = element[0].clientWidth,
                     eleH = element[0].clientHeight;*/


                    /*var eleW = 1600,
                     eleH = 600;*/

                    /*var eleW = 1500,
                     eleH = 700;*/

                    /*var getDims = function(){
                     var w=window,d=document,e=d.documentElement,g=d.getElementsByTagName('body')[0],x=w.innerWidth||e.clientWidth||g.clientWidth,y=w.innerHeight||e.clientHeight||g.clientHeight;
                     return {width: x, height: y};
                     };
                     var dims = getDims();*/
                    //alert(dims.width + "   " + dims.height);
                    /*var eleW = dims.width,
                     eleH = dims.height;*/

                    var eleW = 2000,
                        eleH = 1000;
                    /*var m = [20,40,20,80],
                     w = eleW - m[1] - m[3],
                     h = eleH - m[0] - m[2],
                     i = 0,
                     root;*/
                    var m = [20,40,20,210],
                        w = eleW - m[1] - m[3],
                        h = eleH - m[0] - m[2],
                        i = 0,
                        root;

                    var tree = d3.layout.tree().size([h, w]);
                    var diagonal = d3.svg.diagonal().projection(function(d) { return [d.y, d.x]; });

                    var vis = d3.select(element[0]).append("svg:svg")
                        .attr("width", w + m[1] + m[3])
                        .attr("height", h + m[0] + m[2])
                        .attr("id","svg")
                        .append("svg:g")
                        .attr("transform", "translate(" + m[3] + "," + m[0] + ")");

                    // Toggle children.
                    /*function toggle(d) {
                     alert("Toggle children.");
                     if (d.children) {
                     d._children = d.children;
                     d.children = null;
                     } else {
                     d.children = d._children;
                     d._children = null;
                     }
                     }

                     function toggleAll(d) {
                     if (d.children) {
                     d.children.forEach(toggleAll);
                     toggle(d);
                     }
                     }*/

                    scope.$watch('json' , function(){
                        if(!(scope.json != null)){
                            scope.json = {
                                "name" : "root"
                            }
                        }
                        root = scope.json;
                        root.x0 = h/2;
                        root.y0 = 0;
                        update(root);
                        scope.root = root;
                    });

                    function compactQuestionContent(question, position) {
                        if(question == null || question == undefined || question == '') {
                            return;
                        }
                        var continue_while = true;
                        var result = "";
                        var next_position = position + 1;
                        while(continue_while && next_position <= question.length) {
                            if(question.substring(next_position - 1, next_position) == " ") {
                                continue_while = false;
                                result = question.substring(0, next_position);
                            }
                            next_position = next_position + 1;
                        }

                        if(result == "") {
                            result = question;
                        }
                        return result;

                    };

                    function update(source) {
                        var duration = 500;
                        if(!(source != null)){
                            return;
                        }

                        // Compute the new height, function counts total children of root node and sets tree height accordingly.
                        // This prevents the layout looking squashed when new nodes are made visible or looking sparse when nodes are removed
                        // This makes the layout more consistent.
                        var levelWidth = [1];
                        var aaa = 1;
                        var childCount = function(level, n) {

                            if (n.children && n.children.length > 0) {
                                if (levelWidth.length <= level + 1) levelWidth.push(0);

                                levelWidth[level + 1] += n.children.length;
                                aaa = aaa + 1;
                                n.children.forEach(function(d) {
                                    childCount(level + 1, d);
                                });
                            }
                        };
                        childCount(0, root);
                        var newHeight = d3.max(levelWidth) * 75; // 25 pixels per line
                        tree = tree.size([newHeight, w]);


                        d3.select("svg").attr("height", newHeight + 50);
                        // Compute the new tree layout.

                        var nodes = tree.nodes(root).reverse();

                        // Normalize for fixed-depth.
                        var deepest = 0,
                            generationGutter = w;
                        nodes.forEach(function(d){
                            if(deepest < d.depth){
                                deepest = d.depth;
                            }
                        });
                        generationGutter = Math.floor(w/(deepest+1));
                        nodes.forEach(function(d) { d.y = d.depth * generationGutter; });

                        // Update the nodes…
                        var node = vis.selectAll("g.node")
                            .data(nodes, function(d) { return d.id || (d.id = ++i); });

                        // Enter any new nodes at the parent's previous position.
                        var nodeEnter = node.enter().append("svg:g")
                            .attr("class", "node")
                            .attr("transform", function(d) { return "translate(" + source.y0 + "," + source.x0 + ")"; });

                        //inject content to node
                        InjectNodeContent(nodeEnter);

                        // Transition nodes to their new position.
                        var nodeUpdate = node.transition()
                            .duration(duration)
                            .attr("transform", function(d) { return "translate(" + d.y + "," + d.x + ")"; });

                        nodeUpdate.select("circle")
                            .attr("r", 4.5)
                            .style("fill", function(d) { return d._children ? "lightsteelblue" : "#fff"; });

                        nodeUpdate.select("text")
                            //.text(function(d) { return d.name; })
                            .text(function(d) {
                                if(d.name != null && d.name.length > 25){
                                    return compactQuestionContent(d.name, 20) + "...";
                                    //return d.name.substring(0, 20) + "...";
                                } else {
                                    return d.name;
                                }
                            })
                            .style("fill-opacity", 1);

                        // Transition exiting nodes to the parent's new position.
                        var nodeExit = node.exit().transition()
                            .duration(duration)
                            .attr("transform", function(d) { return "translate(" + source.y + "," + source.x + ")"; })
                            .remove();

                        nodeExit.select("circle")
                            .attr("r", 1e-6);

                        nodeExit.select("text")
                            .style("fill-opacity", 1e-6);

                        // Update the links…
                        var link = vis.selectAll("path.link")
                            .data(tree.links(nodes), function(d) {
                                return d.target.id;
                            });

                        // Enter any new links at the parent's previous position.
                        link.enter().insert("svg:path", "g")
                            .attr("class", "link")
                            .attr("style", function(d) {
                                var stroke_width = 13.9108;
                                var level = 3;
                                if(d.target.level != undefined) {
                                    level = d.target.level;
                                }
                                stroke_width = stroke_width -1.2*level;
                                if(stroke_width < 3) {
                                    stroke_width = 3;
                                }

                                // stroke-opacity
                                var stroke_opacity = 0.35;
                                var level = 3;
                                if(d.target.level != undefined) {
                                    level = d.target.level;
                                }
                                stroke_opacity = stroke_opacity -0.015*level;
                                if(stroke_opacity < 0.15) {
                                    stroke_opacity = 0.15;
                                }

                                if(d.target.type == 0) {
                                    // The question
                                    return "stroke-linecap: round; stroke: #FF6E00 !important; stroke-opacity: " + stroke_opacity + "; stroke-width: " + stroke_width + ";";
                                }else if(d.target.type == 1) {
                                    // The answer
                                    return "stroke-linecap: round; stroke: #007DAB !important; stroke-opacity: " + stroke_opacity + "; stroke-width: " + stroke_width + ";";
                                } else if(d.target.type == 2) {
                                    // Go to the question(Existing)
                                    return "stroke-linecap: round; stroke: #00AF3F !important; stroke-opacity: " + stroke_opacity + "; stroke-width: " + stroke_width + ";";
                                } else if(d.target.type == -1) {
                                    // Terminate survey
                                    return "stroke-linecap: round; stroke: #D70000 !important; stroke-opacity: " + stroke_opacity + "; stroke-width: " + stroke_width + ";";
                                } else {
                                    return "stroke-linecap: round; stroke: #1CA498 !important; stroke-opacity: " + stroke_opacity + "; stroke-width: " + stroke_width + ";";
                                }
                            })
                            /*.attr("class", function (d) {
                             //alert(d.type);
                             if(d.target.type){
                             return "link";
                             }else{
                             return "link3";
                             }
                             })*/
                            /*.attr("class", function (d) {
                             //alert(d.type);
                             return (d.source != root) ? "link" : "link0" ;
                             })*/
                            /*.style("stroke", function(d) {
                             if(d.type == 0)
                             return "#ccc";
                             else
                             return "#154890";
                             })*/
                            .attr("d", function(d) {
                                var o = {x: source.x0, y: source.y0};
                                return diagonal({source: o, target: o});
                            })
                            .transition()
                            .duration(duration)
                            .attr("d", diagonal);

                        // Transition links to their new position.
                        link.transition()
                            .duration(duration)
                            .attr("d", diagonal);

                        // Transition exiting nodes to the parent's new position.
                        link.exit().transition()
                            .duration(duration)
                            .attr("d", function(d) {
                                var o = {x: source.x, y: source.y};
                                return diagonal({source: o, target: o});
                            })
                            .remove();

                        // Stash the old positions for transition.
                        nodes.forEach(function(d) {
                            d.x0 = d.x;
                            d.y0 = d.y;
                        });
                    }


                    function InjectNodeContent (nodeEnter) {
                        nodeEnter.append("svg:circle")
                            .attr("r", 1e-6)
                            .style("stroke", function(d) {
                                if(d.type == 0) {
                                    // The question
                                    return "#FF9500";
                                } else if(d.type == 1) {
                                    // The answer
                                    return "#007DAB";
                                } else if(d.type == -1) {
                                    // Terminate survey
                                    return "#FB0000";
                                } else if(d.type == 2) {
                                    // Goto existing question
                                    return "#00AF3F";
                                } else {
                                    //
                                    return "steelblue";
                                }
                            })
                            .style("stroke-width", function(d) {
                                if(d.type ==0) {
                                    // The question
                                    return "3.5px";
                                } else if(d.type == -1 || d.type == 2) {
                                    // Terminate survey || Goto existing question
                                    return "3.5px";
                                } else if(d.type == 1) {
                                    // The answer
                                    return "2.5px";
                                } else {
                                    return "1.5px";
                                }

                            })
                            .style("fill", function(d) { return d._children ? "lightsteelblue" : "#fff"; })
                            .classed("toggleCircle" , true)
                            .on("click", function(d) {
                                toggle(d);
                                update(d);
                            });

                        nodeEnter.append("svg:text")
                            //.attr("x", function(d) { return d.children || d._children ? -10 : 10; })
                            .attr("x", function(d) {
                                //return d.children || d._children ? -10 : 10;
                                if(d.type ==0) {
                                    // The question
                                    //return -14;
                                    //return 25;
                                    return 0;
                                } else if(d.type == -1 || d.type == 2) {
                                    // Terminate survey || Goto: Existing question
                                    return 10;
                                } else {
                                    // The answer
                                    return 5;
                                }
                            })
                            .attr("y", function(d) {
                                //return d.children || d._children ? -10 : 10;
                                if(d.type == 0) {
                                    // The question
                                    return -12;
                                } else if(d.type == -1 || d.type == 2) {
                                    // Terminate survey || Goto: Existing question
                                    return 0;
                                } else {
                                    // The answer
                                    return 13;
                                }
                            })
                            .attr("dy", ".35em")
                            // text_color
                            .attr("class", function(d) {
                                if(d.type == 1) {
                                    return "text_answer";
                                } else if(d.type == -1) {
                                    return "text_terminate";
                                } else if(d.type == 2) {
                                    return "text_existing_question";
                                }
                            })
                            .attr("text-anchor", function(d) {
                                //return d.children || d._children ? "end" : "start";
                                if(d.type == 0) {
                                    return "middle";
                                    //return "end";
                                } else if(d.type == 1) {
                                    return "start";
                                } else {
                                    return "start";
                                }
                            })
                            .append("text") // added to display the label for axis
                            .text(function(d) { return d.name; })
                            .style("fill-opacity", 1e-6);

                        // Add btn icon
                        nodeEnter.append("svg:path")
                            .attr("d", function(d) {
                                if(d.type == 1 && !(d.children || d._children) && scope.isViewConfirm == 0)
                                    return "M12 24c-6.627 0-12-5.372-12-12s5.373-12 12-12c6.628 0 12 5.372 12 12s-5.372 12-12 12zM12 3c-4.97 0-9 4.030-9 9s4.030 9 9 9c4.971 0 9-4.030 9-9s-4.029-9-9-9zM13.5 18h-3v-4.5h-4.5v-3h4.5v-4.5h3v4.5h4.5v3h-4.5v4.5z";
                                else
                                    return "";
                            })
                            //.attr("d", "M12 24c-6.627 0-12-5.372-12-12s5.373-12 12-12c6.628 0 12 5.372 12 12s-5.372 12-12 12zM12 3c-4.97 0-9 4.030-9 9s4.030 9 9 9c4.971 0 9-4.030 9-9s-4.029-9-9-9zM13.5 18h-3v-4.5h-4.5v-3h4.5v-4.5h3v4.5h4.5v3h-4.5v4.5z")
                            .attr("transform", function(d) {
                                /*var offset = (d.children || d._children) ? -70 : 0;
                                 return "translate(" + offset + "," + 10 + ")";*/
                                return "translate(" + "-11" + ", -" + 11 + ")";
                            })
                            /*.classed("function-btn add", function(d) {
                             if(d.type == 1)
                             return false;
                             else
                             return true;
                             })*/
                            .classed("function-btn add" , true)
                        ;

                        nodeEnter.append("svg:rect")
                            .classed("function-bg add" , true)
                            /*.attr("width" , "24px")
                             .attr("height" , "24px")*/
                            .attr("width", function(d) {
                                if(d.type == 1 && !(d.children || d._children) && scope.isViewConfirm == 0)
                                    return "24px";
                                else
                                    return "0px";
                            })
                            .attr("height", function(d) {
                                if(d.type == 1 && !(d.children || d._children) && scope.isViewConfirm == 0)
                                    return "24px";
                                else
                                    return "0px";
                            })
                            .attr("transform", function(d) {
                                /*var offset = (d.children || d._children) ? -70 : 0;
                                 return "translate(" + offset + "," + 10 + ")";*/
                                return "translate(" + "-11" + ", -" + 11 + ")";
                            })
                            .on("click" , addNewNode);


                        // Remove btn icon
                        nodeEnter.append("svg:path")
                            //.attr("d", "M3.514 20.485c-4.686-4.686-4.686-12.284 0-16.97 4.688-4.686 12.284-4.686 16.972 0 4.686 4.686 4.686 12.284 0 16.97-4.688 4.687-12.284 4.687-16.972 0zM18.365 5.636c-3.516-3.515-9.214-3.515-12.728 0-3.516 3.515-3.516 9.213 0 12.728 3.514 3.515 9.213 3.515 12.728 0 3.514-3.515 3.514-9.213 0-12.728zM8.818 17.303l-2.121-2.122 3.182-3.182-3.182-3.182 2.121-2.122 3.182 3.182 3.182-3.182 2.121 2.122-3.182 3.182 3.182 3.182-2.121 2.122-3.182-3.182-3.182 3.182z")
                            .attr("d", function(d) {
                                //"mark_root": first_question.mark_root
                                if(d.type == 0 && d.mark_root == 0 && scope.isViewConfirm == 0)
                                    return "M3.514 20.485c-4.686-4.686-4.686-12.284 0-16.97 4.688-4.686 12.284-4.686 16.972 0 4.686 4.686 4.686 12.284 0 16.97-4.688 4.687-12.284 4.687-16.972 0zM18.365 5.636c-3.516-3.515-9.214-3.515-12.728 0-3.516 3.515-3.516 9.213 0 12.728 3.514 3.515 9.213 3.515 12.728 0 3.514-3.515 3.514-9.213 0-12.728zM8.818 17.303l-2.121-2.122 3.182-3.182-3.182-3.182 2.121-2.122 3.182 3.182 3.182-3.182 2.121 2.122-3.182 3.182 3.182 3.182-2.121 2.122-3.182-3.182-3.182 3.182z";
                                else
                                    return "";
                            })
                            .attr("transform", function(d) {
                                /*var offset = (d.children || d._children) ? -40 : 30;
                                 return "translate(" + offset + "," + 10 + ")";*/
                                return "translate(" + "-11" + ", -" + 11 + ")";
                            })
                            .classed("function-btn remove" , true)
                            /*.classed("function-btn remove", function(d) {
                             if(d.type == 0)
                             return false;
                             else
                             return true;
                             })*/;

                        nodeEnter.append("svg:rect")
                            .classed("function-bg remove" , true)
                            //.attr("width" , "24px")
                            //.attr("height" , "24px")
                            .attr("width", function(d) {
                                if(d.type == 0 && d.mark_root == 0 && scope.isViewConfirm == 0)
                                    return "24px";
                                else
                                    return "0px";
                            })
                            .attr("height", function(d) {
                                if(d.type == 0 && d.mark_root == 0 && scope.isViewConfirm == 0)
                                    return "24px";
                                else
                                    return "0px";
                            })
                            .attr("transform", function(d) {
                                /*var offset = (d.children || d._children) ? -40 : 30;
                                 return "translate(" + offset + "," + 10 + ")";*/
                                return "translate(" + "-11" + ", -" + 11 + ")";
                            })
                            .on("click" , removeNode);

                        // Edit btn
                        /* nodeEnter.append("svg:path")
                         .attr("d", "M20.307 1.998c-0.839-0.462-3.15-1.601-4.658-1.913-1.566-0.325-3.897 5.79-4.638 5.817-1.202 0.043-0.146-4.175 0.996-5.902-1.782 1.19-4.948 2.788-5.689 4.625-1.432 3.551 2.654 9.942 0.474 10.309-0.68 0.114-2.562-4.407-3.051-5.787-1.381 2.64-0.341 5.111 0.801 8.198v0.192c-0.044 0.167-0.082 0.327-0.121 0.489h0.121v4.48c0 0.825 0.668 1.493 1.493 1.493 0.825 0 1.493-0.668 1.493-1.493v-4.527c2.787-0.314 4.098 0.6 6.007-3.020-1.165 0.482-3.491-0.987-3.009-1.68 0.97-1.396 4.935 0.079 7.462-4.211-4 1.066-4.473-0.462-4.511-1.019-0.080-1.154 3.999-0.542 5.858-2.146 1.078-0.93 2.37-3.133 0.97-3.905z")
                         .attr("transform", function(d) {
                         var offset = (d.children || d._children) ? -10 : 60;
                         return "translate(" + offset + "," + 10 + ")";
                         })
                         .classed("function-btn edit" , true);

                         nodeEnter.append("svg:rect")
                         .classed("function-bg edit" , true)
                         .attr("width" , "24px")
                         .attr("height" , "24px")
                         .attr("transform", function(d) {
                         var offset = (d.children || d._children) ? -10 : 60;
                         return "translate(" + offset + "," + 10 + ")";
                         })
                         .on("click" , editNode);*/


                        function addNewNode (d){
                            // Show popup to choose question
                            scope.openPopupChooseQuestion(d);
                        }

                        function removeNode (d){
                            var thisId = d.id;

                            if (confirm(gettextCatalog.getString("Are you sure to remove branching questions"))) {
                                var list_need_delete = [];
                                var list_deleted_node = [];
                                list_need_delete.push(d.key);
                                while (list_need_delete.length > 0)
                                {
                                    var data_flat_node = scope.data_flat_node;
                                    for (var i =0; i < data_flat_node.length; i++)
                                    {
                                        var flat_node = data_flat_node[i];

                                        // If this node need delete
                                        if ($.inArray(flat_node.key, list_need_delete) >= 0)
                                        {
                                            if(scope.counterQuestionOnMindmap > 1) {
                                                scope.counterQuestionOnMindmap = scope.counterQuestionOnMindmap - 1;
                                            }

                                            // Remove key of node from list the existing questions
                                            scope.data_flat_node.splice(i,1);
                                            var indexOfkey = scope.questionIdExisting.indexOf(("" + d.key));
                                            if(indexOfkey != -1) {
                                                scope.questionIdExisting.splice(indexOfkey, 1);
                                            }

                                            // Remove node from scope
                                            //scope.data_flat_node.splice(i,1);
                                            // This node have child push into list_need_delete[]
                                            if(flat_node.children != undefined && flat_node.children != null)
                                            {
                                                var childrens_of_node = flat_node.children;
                                                for (var j =0; j < childrens_of_node.length; j++) {
                                                    if ($.inArray(childrens_of_node[j].key, list_need_delete) != -1 && $.inArray(childrens_of_node[j].key, list_deleted_node) != -1){
                                                        list_need_delete.push(childrens_of_node[j].key);
                                                    }
                                                }
                                            }
                                            // Remove key of node from list_need_delete[]
                                            list_need_delete.splice(list_need_delete.indexOf(flat_node.key),1);
                                            list_deleted_node.push(flat_node.key);
                                        }

                                        // Node have parent in list_need_delete[] then must also delete
                                        if(flat_node.parentId != undefined && flat_node.parentId != null)
                                        {
                                            var parentOfNode = flat_node.parentId;
                                            if ($.inArray(parentOfNode, list_deleted_node) >= 0 && $.inArray(flat_node.key, list_deleted_node) == -1)
                                            {
                                                list_need_delete.push(flat_node.key);
                                            }
                                        }

                                    }
                                }

                                var data_flat_node = scope.data_flat_node;
                                d.parent.children.forEach(function(c , index){
                                    if(thisId === c.id){
                                        d.parent.children.splice(index , 1);
                                        /*d.parent.children = [];
                                         d.parent._children = null;*/
                                        return;
                                    }
                                });

                                update(d.parent);
                                scope.root = root;
                                scope.drawMindmap();
                            }
                        }

                        function serializeData(source){
                            var json = {};
                            json.name = source.name;
                            var children = source.children || source._children;
                            var childList = [];
                            if(children){
                                children.forEach(function(node){
                                    childList.push(serializeData(node));
                                });
                                json.children = childList;
                            }
                            return json;
                        }

                    }
                }
            }
        })
        .controller('SurveyController', SurveyController);

    SurveyController.$inject = ['DepartmentsService', 'SurveysService', 'QuestionService', '$scope', '$rootScope', '$routeParams', '$route', '$cookieStore', '$location', 'gettextCatalog', '$q', 'cssInjector', 'localStorageService', '$timeout', '$http'];
    function SurveyController(DepartmentsService, SurveysService, QuestionService, $scope, $rootScope, $routeParams, $route, $cookieStore, $location, gettextCatalog, $q, cssInjector, localStorageService, $timeout, $http) {
        $('body').removeClass('signwrapper');
        cssInjector.add("css/quirk.css");
        cssInjector.add("css/custom.css");
        $scope.group_question = [];
        $scope.surveyActive = false;
        $scope.previous_steps = gettextCatalog.getString("Previous");
        $scope.next_steps = gettextCatalog.getString("Next");
        $scope.finish_steps = gettextCatalog.getString("Finish");
        $scope.text_loading = gettextCatalog.getString("Loading please wait");
        $scope.s_department = null;
        $scope.s_question = null;
        $scope.item = {survey_title: "", description: ""};
        $scope.survey_id = null;
        $scope.dtInstance = {};
        $scope.colIdx = 0;

        initController();
        function initController() {
            $.fn.dataTableExt.sErrMode = 'throw';
            var hospitalObj = localStorageService.get('hospitalObj');
            $scope.hospital = hospitalObj.data;
            $scope.departmentList = $scope.hospital.department_list;
            $scope.hospitalObj = $scope.hospital;
            $scope.selectedDept = "";
            $scope.departmentArr = [];

            $('#item01').toggle();

            $.each($scope.departmentList, function (index, value) {
                $scope.departmentArr[value.department_code] = value.department_name;
            });
            // For converting image to base64
            $scope.getDataUri($scope.hospitalObj.logo, function (dataUri) {
                $scope.hospitalLogo = dataUri;
            });

            if ($location.path() == '/survey/create/' + $routeParams.department_code) {
                $cookieStore.remove('show_flg');
                $scope.selectedDept = $routeParams.department_code;
                SurveysService.GetSurveyByDept($scope.selectedDept, function (res) {
                    if (res.status == 1) {
                        $scope.survey = res.data.survey_list;
                    }
                });
                $cookieStore.put('show_flg', false);
                $('#wizard-step .actions').show();
                $('.step1').show();
            } else {
                $('.step1').hide();
            }

            var listClass = [
                'panel-blue',
                'panel-orange',
                'panel-green',
                'panel-brown',
                'panel-pink',
                'panel-red',
                'panel-green2'
            ];

            var listIcon = [
                'panel-icon-1.png',
                'panel-icon-2.png',
                'panel-icon-2.png',
                'panel-icon-4.png',
                'panel-icon-5.png',
                'panel-icon-6.png',
                'panel-icon-7.png'
            ];

            // Get list department by hospital code
            DepartmentsService.GetAll().then(function (res) {
                    var itemLocal = localStorageService.get($cookieStore.get('globals').currentUser.username + 'dept');
                    if (res.status == 1) {
                        res.data.forEach(function (val, index) {
                            var idxClass = (index % 7 == 0) ? 6 : (index % 7 - 1);
                            var idxIcon = (index % 7 == 0) ? 6 : (index % 7 - 1);
                            val.class = listClass[idxClass];
                            val.src = listIcon[idxIcon];
                        });
                        $scope.dept = res.data;
                        $scope.departmentArr1 = [];
                        if (itemLocal != null) {
                            for (var i = 0; i < itemLocal.length; i++) {
                                $.each($scope.dept, function (idx, val) {
                                    if (typeof(val.department_code) != 'undefined') {
                                        if (val.department_code === itemLocal[i]) {
                                            $scope.departmentArr1.push(val);
                                        }
                                    }
                                });
                            }
                            $scope.dept = $scope.departmentArr1;
                        }
                    } else if (res.status == 401) {
                        $cookieStore.remove('globals');
                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                    }
                }
            );

            /**
             * Get all question
             */
            QuestionService.GetAll(null, null, null, function (res) {
                if (res.status == 1) {
                    res.data.question_list.forEach(function (val) {
                        val.selected = false;
                        val.required = false;
                        val.actived = false;
                    });
                    $scope.question_list = res.data.question_list;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                }
            });

            $scope.questionType = [
                {
                    question_type: -1,
                    text: gettextCatalog.getString('All')
                },
                {
                    question_type: 0,
                    text: gettextCatalog.getString('Single choice')
                },
                {
                    question_type: 1,
                    text: gettextCatalog.getString('Multiple choice')
                }
            ];

            $scope.checkedBranchingSurvey = false;

            $scope.questionSelectList = $scope.questionType.slice(1);
            $('#sortable').sortable({
                start: function (e, ui) {
                    ui.item.data('start', ui.item.index());
                },
                update: function (e, ui) {
                    var start = ui.item.data('start'),
                        end = ui.item.index();
                    $scope.dept.splice(end, 0,
                        $scope.dept.splice(start, 1)[0]);
                    $scope.$apply();
                },
                stop: function (e, ui) {
                    var orderDept = [];
                    $scope.dept.forEach(function (val) {
                        orderDept.push(val.department_code);
                    });
                    localStorageService.set($cookieStore.get('globals').currentUser.username + 'dept', orderDept);
                    $scope.$digest();
                },
                axis: "y"
            }).disableSelection();

            $('#limit_answer').on('change', function () {
                if ($('#limit_answer').val() < $scope.answerList.length) {
                    $scope.answerList = $scope.answerList.slice(0, $('#limit_answer').val());
                    $scope.$apply();
                }
            });
        } // end init

        //================Mind Map=================
        function serializeData(source){
            var json = {};
            json.name = source.name;
            var children = source.children || source._children;
            var childList = [];
            if(children){
                children.forEach(function(node){
                    childList.push(serializeData(node));
                });
                json.children = childList;
            }
            return json;
        }

        $scope.new = function(){
            $scope.json =
            {
                "name" : "root"
            };
        }

        $scope.load = function(file){
            var reader = new FileReader();
            reader.onload = function(event){
                var contents = event.target.result;
                //console.log(JSON.parse(contents));
                $scope.json = JSON.parse(contents);
                $scope.$apply();
            }
            reader.readAsText(file);
        }

        $scope.save = function(){
            var saveData = serializeData($scope.root);
            // window.open("data:text/json;charset=utf-8," + escape(JSON.stringify(saveData)));
            var MIME_TYPE = 'application/json';
            var bb = new Blob([JSON.stringify(saveData)], {type: MIME_TYPE});

            var a = document.createElement('a');
            a.download = $scope.fileName + ".json";
            a.href = window.URL.createObjectURL(bb);
            a.textContent = '點擊下載';

            a.dataset.downloadurl = [MIME_TYPE, a.download, a.href].join(':');
            document.querySelectorAll("#downloadLinkWrap")[0].innerHTML = "";
            document.querySelectorAll("#downloadLinkWrap")[0].appendChild(a);
        }
        //===================Mind Map=================

        $scope.changeDepartment = function () {
            $cookieStore.remove('show_flg');
            //var dept = $scope.selectedDept.toString().charAt($scope.selectedDept.length -1);
            SurveysService.GetSurveyByDept($scope.selectedDept, function (res) {
                //SurveysService.GetSurveyByDept(dept).then(function (res) {
                if (res.status == 1) {
                    $scope.survey = res.data.survey_list;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });
            $cookieStore.put('show_flg', false);
            $('#wizard-step .actions').show();
            $('.step1').show();
        };

        /**
         * Show all survey of department by department id
         * @param item
         * @param idx
         */
        $scope.show = function (item, idx) {
            var itemLocal = localStorageService.get($cookieStore.get('globals').currentUser.username + 'survey');
            var deptArr = [];
            var dept_code = null;
            $scope.dept.forEach(function (val) {
                if (val.department_code == item) {
                    dept_code = val.department_code;
                }
            });
            SurveysService.GetSurveyByDept(dept_code, function (res) {
                if (res.status == 1) {
                    res.data.survey_list.forEach(function (value) {
                        if ($.inArray(value.id, itemLocal) == -1) {
                            value.show_flg = 1;
                            deptArr.push(value);
                        }
                    });
                    deptArr.forEach(function (val) {
                        if (val.use_flg == 1) {
                            $timeout(function () {
                                $('#sid' + val.id).attr('style', 'display: none;');
                            }, 1);
                        }
                    });
                    $scope.dept[idx].survey = deptArr;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });
            $('#item' + item).toggle();
            $('#table' + item).css('width', '100%');
        };

        /**
         * Change status of survey (Active/Inactive)
         * @param item
         * @param panel
         * @param pIdx
         */
        $scope.changeStatus = function (item, panel, pIdx) {
            SurveysService.ChangeStatus(item.id, function (res) {
                if (res.status == 1) {
                    $.gritter.add({
                        title: gettextCatalog.getString('Activated'),
                        text: gettextCatalog.getString('Survey was activated'),
                        class_name: 'with-icon times-circle success'
                    });
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });

            if ($('#panel' + panel.department_code + ' .table tr td button.btn-status').hasClass('btn-success')) {
                $('#panel' + panel.department_code + ' .table tr td button.btn-status').removeClass('btn-success');
                $('#panel' + panel.department_code + ' .table tr td button.btn-status').parent().parent().removeClass('active-row');
                $('#panel' + panel.department_code + ' .table tr td button.btn-status').addClass('btn-danger');
                $('#panel' + panel.department_code + ' .table tr td button.btn-status').text(gettextCatalog.getString('InActive'));
                $('.btn-info').attr('style', 'display: inline;');
                $('#sid' + item.id).attr('style', 'display: none;');
                $('.btn-status.btn-danger').attr('style', 'width: auto');
            }
            $('.act' + item.id).removeClass('btn-danger');
            $('.act' + item.id).parent().parent().addClass('active-row');
            $('.act' + item.id).addClass('btn-success');
            $('.act' + item.id).text(gettextCatalog.getString('Active'));
            SurveysService.GetSurveyByDept(panel.department_code, function (res) {
                if (res.status == 1) {
                    //res.data.survey_list.sort(function (a, b) {
                    //    return b.use_flg - a.use_flg;
                    //});
                    $scope.dept[pIdx].survey = res.data.survey_list;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });
        };

        // function group question in survey
        $scope.chooseGroup = function (idx) {
            $('div.question-group').removeClass('active');
            $('#group_index' + idx).addClass('active');

            $scope.group_question.forEach(function (val) {
                val.active = 0;
            });
            $scope.group_question[idx].active = 1;
        };

        $scope.addGroup = function () {
            var group = {
                group_id: null,
                title: null,
                question_list: [],
                active: 0
            };
            $scope.group_question.push(group);
        };

        $scope.delGroup = function (idx) {
            $scope.group_question.splice(idx, 1);
        };

        $scope.searchQuestion = function () {
            var dept = null;
            var qt = -1;
            var title = null;
            if ($('#select2').val() != '' && $('#select2').val() != -1) {
                qt = $('#select2').val();
            }
            if ($('#select1').val() != '' && $('#select1').val() != -1) {
                dept = $('#select1').val();
            }
            if ($('#question_title').val() != '') {
                title = $('#question_title').val();
            }

            QuestionService.GetAll(dept, qt, title, function (res) {
                if (res.status == 1) {
                    res.data.question_list.forEach(function (val) {
                        val.selected = false;
                        val.actived = false;
                        val.required = false;
                    });
                    $scope.question_list = res.data.question_list;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });
        };

        $scope.detailQuestion = function (question) {
            QuestionService.getDetailQuestion(question.question_id).then(function (res) {
                if (res.status == 1) {
                    $scope.questionObj = res.data;
                    $('#question-title').text('');
                    $('#question-title').append($scope.questionObj.question_content + '<br><div style="font-size: 12px;color: #FFFFFF;">' + $scope.questionObj.description + '</div>');
                    $('#question-popup ul.box-list-item').html('');
                    $.each($scope.questionObj.answer_list, function (index, value) {
                        if ($scope.questionObj.question_type == 1) { // Checkbox
                            if (value.is_correct == 1) {
                                $('#question-popup ul.box-list-item').append('<li><label class="ckbox"><input type="checkbox" disabled="disable" style="float: left"/>&nbsp;<span class="item_name">' + value.title + '</span><span style="color: red;"> (' + gettextCatalog.getString('Correct') + ')</span></label></li>');
                            } else {
                                $('#question-popup ul.box-list-item').append('<li><label class="ckbox"><input type="checkbox" disabled="disable" style="float: left"/>&nbsp;<span class="item_name">' + value.title + '</span></label></li>');
                            }
                        } else { // Radio
                            if (value.is_correct == 1) {
                                $('#question-popup ul.box-list-item').append('<li><label class="rdio form-control"><input type="radio" disabled="disable" style="float: left"/>&nbsp;<span class="item_name">' + value.title + '</span><span style="color: red;"> (' + gettextCatalog.getString('Correct') + ')</span></label></li>');
                            } else {
                                $('#question-popup ul.box-list-item').append('<li><label class="rdio form-control"><input type="radio" disabled="disable" style="float: left"/>&nbsp;<span class="item_name">' + value.title + '</span></label></li>');

                            }
                        }
                    });

                    if ($scope.questionObj.has_other_answer == true) {
                        var text = 'Input other answer';
                        $('#question-popup ul.box-list-item').append('<li><input type="text" class="form-control" disabled="disabled" placeholder="' + gettextCatalog.getString(text) + '"/></li>');
                    }

                    // For filtering on list quesion
                    $("#filter").bind("keyup", function () {
                        var text = $(this).val().toLowerCase();
                        var items = $(".item_name");

                        //first, hide all:
                        items.parent().parent().hide();

                        //show only those matching user input:
                        items.filter(function () {
                            return $(this).text().toLowerCase().indexOf(text) > -1;
                        }).parent().parent().show();
                    });

                    $('#question-popup').modal('show');
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                }
            });
        };

        $scope.addQuestion = function () {
            var selectErr = 0;
            var activeErr = 0;
            var countErr = 0;
            if ($scope.group_question.length > 0) {
                var arr = [];
                $scope.question_list.forEach(function (value, index) {
                    if (value.selected == true) {
                        value.required = false;
                        value.position = index;
                        arr.push(value);
                        selectErr++;
                        value.selected = false;
                    }
                });
                $scope.group_question.forEach(function (val) {
                    if (val.active == 1) {
                        activeErr++;
                        /*for each xx
                         if !xx.item in  val.questions then push xx.item to val.questions*/
                        arr.forEach(function (a) {
                            var newObj = (JSON.parse(JSON.stringify(a))); // clone to new obj
                            var qId = [];
                            val.question_list.forEach(function (value) {
                                // Get detail answer for each selected question
                                QuestionService.getDetailQuestion(value.question_id).then(function (res) {
                                    if (res.status == 1) {
                                        value.answer_list = res.data.answer_list;
                                        value.has_other_answer = res.data.has_other_answer;
                                    } else if (res.status == 401) {
                                        $cookieStore.remove('globals');
                                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                                    } else {
                                        $location.path("/")
                                    }
                                });
                                qId.push(value.question_id);
                            });

                            if ($.inArray(newObj.question_id, qId) == -1) { // check question exist.
                                newObj.activedValue = false;

                                // Get detail answer for each selected question
                                QuestionService.getDetailQuestion(newObj.question_id).then(function (res) {
                                    if (res.status == 1) {
                                        newObj.answer_list = res.data.answer_list;
                                        newObj.has_other_answer = res.data.has_other_answer;
                                    } else if (res.status == 401) {
                                        $cookieStore.remove('globals');
                                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                                    } else {
                                        $location.path('/');
                                    }
                                });

                                val.question_list.push(newObj);
                                countErr++;
                            }
                        });
                    }
                });
            }
            if ($scope.group_question.length == 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('No group question is exist'),
                    text: gettextCatalog.getString('Please, add group question'),
                    class_name: 'with-icon times-circle danger'
                });
            } else if (selectErr == 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('No question is selected'),
                    text: gettextCatalog.getString('Please, choose question.'),
                    class_name: 'with-icon times-circle danger'
                });
            } else if (activeErr == 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('No group question activated'),
                    text: gettextCatalog.getString('Please, choose group question.'),
                    class_name: 'with-icon times-circle danger'
                });
            } else if (countErr == 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('Question is exist'),
                    text: gettextCatalog.getString('Please, choose other question.'),
                    class_name: 'with-icon times-circle danger'
                });
            }
        };

        $scope.editQuestion = function (item) {
            $.ajax({
                url: 'cms/question/' + item.question_id,
                type: 'GET',
                headers: {
                    token: $http.defaults.headers.common['token']
                },
                async: false,
                success: function (response) {
                    var data = response.data;
                    if (response.status == 1) {
                        $scope.department_code = data.department_code;
                        $scope.question_type = data.question_type;
                        $scope.questionObj = data;
                        $scope.answerList = data.answer_list;
                        // Set is_correct to true | false to use for ng-modal
                        $.each($scope.answerList, function (index, value) {
                            value.is_correct = (value.is_correct == 1) ? true : false;
                        });
                    } else if (response.status == 401) {
                        $cookieStore.remove('globals');
                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                    }
                    else {
                        $location.path('/');
                    }
                },
                error: function (response) {
                    $location.path('/');
                }
            });
            $('#question-edit-title').text(gettextCatalog.getString('Edit question') + ':' + $scope.questionObj.question_content);
            $('#question-edit-popup').modal('show');
        };

        // Add more answer into question
        $scope.addOption = function () {
            var idx = 0;
            if ($scope.question_type == 0) {
                var obj = {
                    type: 'radio',
                    name: 'rdio',
                    title: '',
                    is_correct: false
                }
            } else {
                var obj = {
                    type: 'checkbox',
                    name: 'rdio',
                    title: '',
                    is_correct: false
                }
            }

            if ($scope.answerList.length >= limitAnswer) {
                var msg = 'Please enter no more than 10 answers';
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString(msg),
                    class_name: 'with-icon times-circle danger'
                });
                return;
            }
            obj.sequence = $scope.answerList.length + 1;
            $scope.answerList.push(obj);
            $scope.answerList.forEach(function (value, index) {
                idx = index;
            });
            setTimeout(function () {
                $('#input-answer' + idx).focus();
            }, 100);
        };

        // Remove an answer from list
        $scope.removeAnswer = function (id) {
            if (id > -1) {
                $scope.answerList.splice(id, 1);
            }
            $('#answer_item' + id).remove();

            // Update index
            $.each($scope.answerList, function (index, value) {
                value.sequence = index + 1;
            });
        };

        // Change question type
        $scope.changeType = function () {
            $scope.answerList = [];
        };

        // For create new or edit question
        $scope.saveQuestion = function () {
            // Get parameter to check
            var dept = $('#department_selected').val();
            var type = parseInt($('#question-type').val());
            var question = $('#question').val();
            var description = $('#description').val();
            var numAns = 0;
            var checked = true;

            if (question.length > 256 || question.length <= 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('Edit question'),
                    text: gettextCatalog.getString('Missing required fields'),
                    class_name: 'with-icon times-circle danger'
                });
                return;
            }

            if (description.length > 255) {
                $.gritter.add({
                    title: gettextCatalog.getString('Edit question'),
                    text: gettextCatalog.getString('Missing required fields'),
                    class_name: 'with-icon times-circle danger'
                });
                return;
            }

            if (dept == '' || question == '' || isNaN(type)) {
                $.gritter.add({
                    title: gettextCatalog.getString('Create question'),
                    text: gettextCatalog.getString('Missing required fields'),
                    class_name: 'with-icon times-circle danger'
                });
            } else { // If data is validated

                if ($scope.answerList.length < 1) { // Check if does not have any answer => must have to have other answer
                    $.gritter.add({
                        title: gettextCatalog.getString('Question'),
                        text: gettextCatalog.getString('Question must have at least one answer'),
                        class_name: 'with-icon times-circle danger'
                    });
                    return;
                }

                $.each($scope.answerList, function (index, value) {
                    if (value.title == '' || typeof (value.title) == 'undefined' || value.title.length > 128 || value.title.length <= 0) {
                        checked = false;
                        numAns++;
                        $('#input-answer' + index).parent().addClass('has-error');
                        $('#input-answer' + index).focus();
                    } else {
                        $('#input-answer' + index).parent().removeClass('has-error');
                    }
                });

                if (numAns > 0) {
                    $.gritter.add({
                        title: gettextCatalog.getString('Edit question'),
                        text: gettextCatalog.getString('Missing required fields'),
                        class_name: 'with-icon times-circle danger'
                    });
                    return;
                }

                if (checked) {
                    // Set parameters
                    $scope.questionObj.hosp_code = $scope.hospitalObj.hosp_code;
                    $scope.questionObj.department_code = dept;
                    $scope.questionObj.question_type = type;
                    $scope.questionObj.question_content = question;
                    $scope.questionObj.description = description;
                    if ($('#has_other_answer').is(':checked')) {
                        $scope.questionObj.has_other_answer = true;
                    } else {
                        $scope.questionObj.has_other_answer = false;
                    }
                    $scope.questionObj.limit_answer = parseInt($('#limit_answer').val());
                    //if (typeof($scope.questionObj.question_id) != 'undefined') { // Check if edit
                    // Change data type
                    $.each($scope.answerList, function (index, value) {
                        // Re-set is_correct value to 1 | 0
                        if (value.is_correct) {
                            value.is_correct = 1;
                        } else {
                            value.is_correct = 0;
                        }
                        value.is_selected = 0;
                        delete value.name;
                        delete value.type;
                        delete value.checked;
                    });
                    //var newObject = $scope.answerList;
                    $scope.questionObj.answer_list = $scope.answerList;
                    QuestionService.createQuestion($scope.questionObj, function (response) {
                        if (response.success) {
                            // Success
                            $.gritter.add({
                                title: gettextCatalog.getString('Save question'),
                                text: gettextCatalog.getString('Question was saved successful.'),
                                class_name: 'with-icon check-circle success'
                            });
                            $('#question-edit-popup').modal('hide');
                            $scope.group_question.forEach(function (value, index) {
                                value.question_list.forEach(function (val, idx) {
                                    if (val.question_id == $scope.questionObj.question_id) {
                                        $scope.group_question[index].question_list[idx] = $scope.questionObj;
                                    }
                                })
                            });
                            $scope.question_list.forEach(function (value, index) {
                                if (value.question_id == $scope.questionObj.question_id) {
                                    $scope.question_list[index] = $scope.questionObj;
                                }
                            });
                        } else {
                            $.gritter.add({
                                title: gettextCatalog.getString('Delete'),
                                text: response.message,
                                class_name: 'with-icon times-circle danger'
                            });
                        }
                    });
                }
            }
        };

        $scope.validateAnswer = function (idx) {
            if ($('#input-answer' + idx).val() != '' || $('input-answer' + idx).val() != null) {
                $('#input-answer' + idx).parent().removeClass('has-error');
            } else {
                $('#input-answer' + idx).parent().addClass('has-error');
            }
        };

        // If question type is radio
        $scope.setCorrectAnser = function (idx) {
            if ($('#question-type').val() == 0) {
                $.each($scope.answerList, function (index, value) {
                    value.is_correct = 0;
                });
                $scope.answerList[idx].is_correct = 1;
                $('#radio' + idx).prop('checked', true);
            }
            $scope.answerList[idx].checked = 1;
        };

        /**
         * Remove question into a group
         * @param idx
         * @param pidx
         */
        $scope.delQuestion = function (idx, pidx) { //del a question
            $scope.group_question[pidx].question_list.splice(idx, 1);
        };

        $scope.confirmDelQuestionInList = function (idx, pidx, questionId) { //del a question
            if($scope.edit_survey_type !== undefined && $scope.edit_survey_type == 2) {
                var survey_matrix = $scope.edit_survey_matrix;
                var existing = false;
                if(survey_matrix !== null) {
                    survey_matrix.forEach(function (matrix) {
                        if(matrix.source_question_id == questionId || matrix.destination_question_id == questionId) {
                            existing = true;
                        }
                    });
                }

                if(existing) {
                    $scope.delete_question_idx = idx;
                    $scope.delete_question_pidx = pidx;
                    $scope.delete_question_questionId = questionId;

                    $('#confirm-delete-question').modal('show');
                    /*if (confirm(gettextCatalog.getString("This is question in list of branching question"))) {
                        $scope.group_question[pidx].question_list.splice(idx, 1);

                        // Update lại matrix
                        $scope.updateSurveyMatrixAfterDelete(questionId);
                    }*/
                } else {
                    $scope.group_question[pidx].question_list.splice(idx, 1);
                }
            } else {
                $scope.group_question[pidx].question_list.splice(idx, 1);
            }

        };

        $scope.closeConfirmDeleteQuestion = function () {
            $('#confirm-delete-question').modal('hide');
        };

        /**
         * Remove question into a group
         * @param idx
         * @param pidx
         */
        $scope.delQuestionInList = function (idx, pidx, questionId) { //del a question
            if($scope.edit_survey_type !== undefined && $scope.edit_survey_type == 2) {
                var survey_matrix = $scope.edit_survey_matrix;
                var existing = false;
                if(survey_matrix !== null) {
                    survey_matrix.forEach(function (matrix) {
                        if(matrix.source_question_id == questionId || matrix.destination_question_id == questionId) {
                            existing = true;
                        }
                    });
                }

                if(existing) {
                    if (confirm(gettextCatalog.getString("This is question in list of branching question"))) {
                        $scope.group_question[pidx].question_list.splice(idx, 1);

                        // Update lại matrix
                        $scope.updateSurveyMatrixAfterDelete(questionId);
                    }
                } else {
                    $scope.group_question[pidx].question_list.splice(idx, 1);
                }
            } else {
                $scope.group_question[pidx].question_list.splice(idx, 1);
            }

        };

        $scope.delQuestionInListAfterConfirm = function () { //del a question
            var idx = $scope.delete_question_idx;
            var pidx = $scope.delete_question_pidx;
            var questionId = $scope.delete_question_questionId;

            if($scope.edit_survey_type !== undefined && $scope.edit_survey_type == 2) {
                var survey_matrix = $scope.edit_survey_matrix;
                var existing = false;
                if(survey_matrix !== null) {
                    survey_matrix.forEach(function (matrix) {
                        if(matrix.source_question_id == questionId || matrix.destination_question_id == questionId) {
                            existing = true;
                        }
                    });
                }

                if(existing) {
                    $scope.group_question[pidx].question_list.splice(idx, 1);
                    // Update lại matrix
                    $scope.updateSurveyMatrixAfterDelete(questionId);
                } else {
                    $scope.group_question[pidx].question_list.splice(idx, 1);
                }
            } else {
                $scope.group_question[pidx].question_list.splice(idx, 1);
            }
            $('#confirm-delete-question').modal('hide');
        };


        $scope.updateSurveyMatrixAfterDelete = function (questionId) {
            var survey_matrix = $scope.edit_survey_matrix;

            // Case 1: Xóa matrix có destinationId = questionId
            for (var i =0; i < survey_matrix.length; i++){
                var matrix = survey_matrix[i];
                if(matrix.destination_question_id == questionId) {
                    survey_matrix.splice(i, 1);
                }
            };

            // Case 2: Xóa matrix có sourceId = questionId
            var list_need_delete = [];
            var list_key_deleted = [];
            list_need_delete.push(questionId);
            while (list_need_delete.length > 0)
            {
                for (var k =0; k < list_need_delete.length; k++){
                    var key = list_need_delete[k];
                    var list_need_delete_index = [];
                    var survey_matrix_temp = [];
                    for (var i =0; i < survey_matrix.length; i++){
                        var matrix = survey_matrix[i];
                        survey_matrix_temp.push(matrix);
                    };
                    for (var i =0; i < survey_matrix.length; i++){
                        var matrix = survey_matrix[i];
                        if(matrix.source_question_id == key) {
                            //if($.inArray(matrix.source_question_id, list_need_delete) >= 0) {
                            //list_need_delete_index.push(i);
                            var indexOfkey = survey_matrix_temp.indexOf(matrix);
                            survey_matrix_temp.splice(indexOfkey, 1);
                            list_key_deleted.push(matrix.source_question_id);
                            //survey_matrix.splice(i, 1);
                            // Add destination into list_need_delete
                            list_need_delete.push(matrix.destination_question_id);
                        }
                    };
                    survey_matrix = survey_matrix_temp;

                    var indexOfkey = list_need_delete.indexOf(key);
                    list_need_delete.splice(indexOfkey, 1);
                }
            }
            $scope.edit_survey_matrix = survey_matrix;
        };

        /**
         * Remove questions into a group
         */
        $scope.delQuestions = function () { // del all question in group selected
            var lengSelected = 0;
            $scope.group_question.forEach(function (val, index) {
                var arrDel = [];
                for (var i = 0; i < val.question_list.length; i++) {
                    if (val.question_list[i].activedValue == true) {
                        lengSelected++;
                        arrDel.push(i);
                    }
                }
                var count = 0;
                arrDel.forEach(function (value) {
                    var idx = value - count;
                    val.question_list.splice(idx, 1);
                    count++;
                });
                $('#checkAll' + index).attr('checked', false);
            });
            if (lengSelected == 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('No question is selected'),
                    text: gettextCatalog.getString('Please, choose question.'),
                    class_name: 'with-icon times-circle danger'
                });
            }
        };

        // check to required question or not
        $scope.requireQuestion = function (idx, pidx) { //mark up require a question
            if ($('#require' + idx + pidx).hasClass('active')) {
                $scope.group_question[pidx].question_list[idx].required = false;
            } else {
                $scope.group_question[pidx].question_list[idx].required = true;
            }
            $('#require' + idx + pidx).toggleClass('active');
            $('#require' + idx + pidx).toggleClass('btn-set-requited');
        };

        /**
         * Chooses all question into a group to remove
         * @param item
         */
        $scope.checkAll = function (item) {
            if ($('#checkAll' + item).is(':checked')) {
                $scope.selectedAll = true;
            } else {
                $scope.selectedAll = false;
            }
            $scope.group_question[item].question_list.forEach(function (val) {
                val.activedValue = $scope.selectedAll;
            });
        };

        /**
         *   Validate content survey (question group, question)
         */
        $scope.validate_question = function () {
            var numQ = 0;
            var numTit = 0;
            $scope.group_question.forEach(function (value) {
                /**
                 * Max length of title group question must be less than 256 characters.
                 */
                if (typeof (value.title) == 'undefined' || (value.title != null && value.title.length > 256)) {
                    numTit++;
                }
                /**
                 * Group question must be at least one question
                 */
                if (value.question_list.length == 0) {
                    numQ++;
                }
            });

            /**
             * Survey must be at least one group question
             */
            if ($scope.group_question.length <= 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('Create Survey'),
                    text: gettextCatalog.getString('Survey must have at least one group question'),
                    class_name: 'with-icon times-circle danger'
                });
            }

            if (numQ > 0) {
                $.gritter.add({
                    title: gettextCatalog.getString('Create Survey'),
                    text: gettextCatalog.getString('Some group question has no question.'),
                    class_name: 'with-icon times-circle danger'
                });
            }
            return ($scope.group_question.length > 0 && numQ <= 0 && numTit <= 0) ? true : false;
        };

        /**
         * Choose old survey to clone
         * @param item
         */
        $scope.chooses = function (item) {
            SurveysService.GetDetailSurvey(item.id, function (res) {
                res.data.question_group.forEach(function (val) {
                    val.active = 0;
                    val.question_list.forEach(function (vl) {
                        vl.selected = false;
                        vl.required = false;
                        vl.actived = false;
                    })
                });
                $scope.group_question = res.data.question_group;
                $scope.item = res.data;
            });
        };

        /**
         * Draw mind map
         */
        $scope.drawMindmap = function () {
            $scope.isViewConfirm = 0;

            if($scope.data_flat_node == null || $scope.data_flat_node.length == 0){
                // CASE INIT
                $scope.root = null;
                $scope.fileName = "mindMap";
                var jsonData = {};
                var first_group_question = $scope.group_question[0];
                var first_question = first_group_question.question_list[0];
                var first_question_answer_list = first_question.answer_list;

                $scope.questionRootId = first_question.question_id;
                $scope.counterQuestionOnMindmap = 1;
                $scope.questionIdExisting = [(first_question.question_id +"")];

                jsonData.name = first_question.question_content;
                jsonData.children = [];
                first_question_answer_list.forEach(function (val, idx) {
                    var q = {name: val.title};
                    jsonData.children.push(q);
                });

                //====================================Convert data to draw==========================================
                var data = [
                    { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                ];
                first_question_answer_list.forEach(function (val, idx) {
                    data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":first_question.question_content , "parentId":first_question.question_id, "mark_root": 0});
                });
                var dataMap = data.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                data.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.data_flat_node = data;
                $scope.json = treeData[0];
                $scope.$apply();
                //==============================================================================
            } else {
                // CASE BACK
                var data_flat_node = $scope.data_flat_node;
                $scope.confirmType = false;
                if(data_flat_node.length > 1) {
                    $scope.confirmType = true;
                    // Convert node format
                    var convertData = [];
                    for (var i =0; i < data_flat_node.length; i++) {
                        if( data_flat_node[i].parent == undefined || data_flat_node[i].parent == null) {
                            var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": 0, "mark_root": data_flat_node[i].mark_root};
                            convertData.push(nodeData);
                        }else{
                            var parent = null;
                            var pO = data_flat_node[i].parent;
                            if(typeof data_flat_node[i].parent !== 'string') {
                                parent = data_flat_node[i].parent.name;
                            }
                            var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": data_flat_node[i].type, "parent": "" + parent , "parentId": data_flat_node[i].parentId, "mark_root": data_flat_node[i].mark_root};
                            convertData.push(nodeData);
                        }
                    }

                    var dataMap = convertData.reduce(function(map, node) {
                        map[node.key] = node;
                        return map;
                    }, {});

                    var treeData = [];
                    convertData.forEach(function(node) {
                        // add to parent
                        var parent = dataMap[node.parentId];
                        if (parent) {
                            // create child array if it doesn't exist
                            (parent.children || (parent.children = []))
                                // add node to child array
                                .push(node);
                        } else {
                            // parent is null or missing
                            treeData.push(node);
                        }
                    });
                    $scope.json = treeData[0];
                } else {
                    $scope.confirmType = false;
                }
                $scope.$apply();
            }

        };

        // Prepare branching data
        $scope.prepareBranching = function () {
            if($scope.branching_data == undefined || $scope.branching_data == null) {
                // Case 01: New

                // result search ***
                var list_group = [];
                $scope.group_question.forEach(function (value, index) {
                    var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                    var questionData = [];
                    value.question_list.forEach(function (val, idx) {
                        questionData.push(val);
                    });
                    groupData.question_list = questionData;
                    list_group.push(groupData);
                });
                $scope.group_question_result_search = list_group;
                // END result search ***

                var branching_data = [];

                $scope.group_question_result_search.forEach(function (value, index) {
                    value.question_list.forEach(function (val, idx) {
                        var content_qt = val.question_content;
                        if(content_qt.length > 50) {
                            content_qt = content_qt.substring(0, 50) + "...";
                        }
                        var questionType = "";
                        if(val.question_type == 0) {
                            questionType = gettextCatalog.getString('Single choice');
                        } else if(val.question_type == 1) {
                            questionType = gettextCatalog.getString('Multiple choice');
                        } else if(val.question_type == 2) {
                            questionType = gettextCatalog.getString('Input text');
                        }
                        var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                        val.answer_list.forEach(function (awer, ix) {
                            if(val.question_type == 2 || val.question_type == "2") {
                                var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": "-1"};
                                questionData.answer_list.push(answer);
                            } else {
                                var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": "-1"};
                                questionData.answer_list.push(answer);
                            }
                        });

                        // If has_other_answer then add answer_list
                        if(val.has_other_answer) {
                            var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": "-1"};
                            questionData.answer_list.push(answer);
                        }

                        branching_data.push(questionData);
                    });
                });

                $scope.branching_data = branching_data;
                $scope.selected_question_one = branching_data[0];

                // List of destination question
                var selectedQuestionId = $scope.selected_question_one.question_id;
                var isStartChoose = false;
                var listQuestionToBranching = [];

                $scope.group_question.forEach(function(gp) {
                    var listQuestion = [];
                    gp.question_list.forEach(function(qs) {
                        if(qs.question_id == selectedQuestionId) {
                            isStartChoose = true;
                        }

                        if(isStartChoose && qs.question_id !== selectedQuestionId) {
                            listQuestion.push(qs);
                        }
                    });
                    if(listQuestion.length > 0) {
                        var data = {"group": gp.title, "list": listQuestion}
                        listQuestionToBranching.push(data);
                    }
                });
                $scope.listQuestionToBranching = listQuestionToBranching;

                //=============================Mind map==================+++++======
                // CASE INIT
                $scope.root = null;
                $scope.fileName = "mindMap";
                var jsonData = {};
                //console.log("aaa: " + JSON.stringify($scope.group_question));

                var first_group_question = $scope.group_question[0];
                var first_question = first_group_question.question_list[0];
                var first_question_answer_list = first_question.answer_list;

                $scope.questionRootId = first_question.question_id;
                $scope.counterQuestionOnMindmap = 1;
                $scope.questionIdExisting = [(first_question.question_id +"")];

                jsonData.name = first_question.question_content;
                jsonData.children = [];
                first_question_answer_list.forEach(function (val, idx) {
                    var q = {name: val.title};
                    jsonData.children.push(q);
                });

                //====================================Convert data to draw==========================================
                var data = [
                    { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                ];

                var parent = first_question.question_content;
                var parentId = first_question.question_id;
                $scope.group_question.forEach(function (groupData) {
                    groupData.question_list.forEach(function (question) {
                        if(question.question_id != first_question.question_id) {
                            data.push({ "key":question.question_id, "name" : question.question_content, "type": 0, "parent":parent, "parentId":parentId, "mark_root": 0});
                            parent = question.question_content;
                            parentId = question.question_id;
                        }
                    });
                });

                var dataMap = data.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                data.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.data_flat_node = data;
                $scope.json = treeData[0];
                $scope.$apply();

                $('.row-question').removeClass('active_question_row');
                $('#question' + $scope.selected_question_one.question_id).addClass('active_question_row');
                //============================END Mind map==========================
            } else {
                // Case 02: Prev

                // result search ***
                var list_group = [];
                $scope.group_question.forEach(function (value, index) {
                    var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                    var questionData = [];
                    value.question_list.forEach(function (val, idx) {
                        questionData.push(val);
                    });
                    groupData.question_list = questionData;
                    list_group.push(groupData);
                });
                $scope.group_question_result_search = list_group;
                // END result search ***

                var branching_data = [];
                $scope.group_question_result_search.forEach(function (value, index) {
                    value.question_list.forEach(function (val, idx) {
                        var content_qt = val.question_content;
                        if(content_qt.length > 50) {
                            content_qt = content_qt.substring(0, 50) + "...";
                        }
                        var questionType = "";
                        if(val.question_type == 0) {
                            questionType = gettextCatalog.getString('Single choice');
                        } else if(val.question_type == 1) {
                            questionType = gettextCatalog.getString('Multiple choice');
                        } else if(val.question_type == 2) {
                            questionType = gettextCatalog.getString('Input text');
                        }
                        var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                        val.answer_list.forEach(function (awer, ix) {
                            if(val.question_type == 2 || val.question_type == "2") {
                                var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": "-1"};
                                questionData.answer_list.push(answer);
                            } else {
                                var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": "-1"};
                                questionData.answer_list.push(answer);
                            }
                        });

                        // If has_other_answer then add answer_list
                        if(val.has_other_answer) {
                            var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": "-1"};
                            questionData.answer_list.push(answer);
                        }

                        branching_data.push(questionData);
                    });
                });

                $scope.branching_data = branching_data;
                $scope.selected_question_one = branching_data[0];

                // List of destination question
                var selectedQuestionId = $scope.selected_question_one.question_id;
                var isStartChoose = false;
                var listQuestionToBranching = [];

                $scope.group_question.forEach(function(gp) {
                    var listQuestion = [];
                    gp.question_list.forEach(function(qs) {
                        if(qs.question_id == selectedQuestionId) {
                            isStartChoose = true;
                        }

                        if(isStartChoose && qs.question_id !== selectedQuestionId) {
                            listQuestion.push(qs);
                        }
                    });
                    if(listQuestion.length > 0) {
                        var data = {"group": gp.title, "list": listQuestion}
                        listQuestionToBranching.push(data);
                    }
                });
                $scope.listQuestionToBranching = listQuestionToBranching;
                $scope.$apply();

                $('.row-question').removeClass('active_question_row');
                $('#question' + $scope.selected_question_one.question_id).addClass('active_question_row');
            }

        };

        $scope.prepareBranchingEdit = function () {

            // Only do when have branching
            if($scope.checkedBranchingSurvey) {

                if($scope.edit_survey_type == 1) {
                    // Case 01: Old survey is no branching ==> Same case create new branching
                    var list_group = [];
                    $scope.group_question.forEach(function (value, index) {
                        var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                        var questionData = [];
                        value.question_list.forEach(function (val, idx) {
                            questionData.push(val);
                        });
                        groupData.question_list = questionData;
                        list_group.push(groupData);
                    });
                    $scope.group_question_result_search = list_group;
                    // END result search ***

                    var branching_data = [];

                    $scope.group_question_result_search.forEach(function (value, index) {
                        value.question_list.forEach(function (val, idx) {
                            var content_qt = val.question_content;
                            if(content_qt.length > 50) {
                                content_qt = content_qt.substring(0, 50) + "...";
                            }
                            var questionType = "";
                            if(val.question_type == 0) {
                                questionType = gettextCatalog.getString('Single choice');
                            } else if(val.question_type == 1) {
                                questionType = gettextCatalog.getString('Multiple choice');
                            } else if(val.question_type == 2) {
                                questionType = gettextCatalog.getString('Input text');
                            }
                            var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                            val.answer_list.forEach(function (awer, ix) {
                                if(val.question_type == 2 || val.question_type == "2") {
                                    var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": "-1"};
                                    questionData.answer_list.push(answer);
                                } else {
                                    var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": "-1"};
                                    questionData.answer_list.push(answer);
                                }
                            });

                            // If has_other_answer then add answer_list
                            if(val.has_other_answer) {
                                var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": "-1"};
                                questionData.answer_list.push(answer);
                            }

                            branching_data.push(questionData);
                        });
                    });

                    $scope.branching_data = branching_data;
                    $scope.selected_question_one = branching_data[0];

                    // List of destination question
                    var selectedQuestionId = $scope.selected_question_one.question_id;
                    var isStartChoose = false;
                    var listQuestionToBranching = [];

                    $scope.group_question.forEach(function(gp) {
                        var listQuestion = [];
                        gp.question_list.forEach(function(qs) {
                            if(qs.question_id == selectedQuestionId) {
                                isStartChoose = true;
                            }

                            if(isStartChoose && qs.question_id !== selectedQuestionId) {
                                listQuestion.push(qs);
                            }
                        });
                        if(listQuestion.length > 0) {
                            var data = {"group": gp.title, "list": listQuestion}
                            listQuestionToBranching.push(data);
                        }
                    });
                    $scope.listQuestionToBranching = listQuestionToBranching;

                    //=============================Mind map==================+++++======
                    // CASE INIT
                    $scope.root = null;
                    $scope.fileName = "mindMap";
                    var jsonData = {};
                    var first_group_question = $scope.group_question[0];
                    var first_question = first_group_question.question_list[0];
                    var first_question_answer_list = first_question.answer_list;

                    $scope.questionRootId = first_question.question_id;
                    $scope.counterQuestionOnMindmap = 1;
                    $scope.questionIdExisting = [(first_question.question_id +"")];

                    jsonData.name = first_question.question_content;
                    jsonData.children = [];
                    first_question_answer_list.forEach(function (val, idx) {
                        var q = {name: val.title};
                        jsonData.children.push(q);
                    });

                    //====================================Convert data to draw==========================================
                    var data = [
                        { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                    ];

                    var parent = first_question.question_content;
                    var parentId = first_question.question_id;
                    $scope.group_question.forEach(function (groupData) {
                        groupData.question_list.forEach(function (question) {
                            if(question.question_id != first_question.question_id) {
                                data.push({ "key":question.question_id, "name" : question.question_content, "type": 0, "parent":parent, "parentId":parentId, "mark_root": 0});
                                parent = question.question_content;
                                parentId = question.question_id;
                            }
                        });
                    });

                    var dataMap = data.reduce(function(map, node) {
                        map[node.key] = node;
                        return map;
                    }, {});

                    var treeData = [];
                    data.forEach(function(node) {
                        // add to parent
                        var parent = dataMap[node.parentId];
                        if (parent) {
                            // create child array if it doesn't exist
                            (parent.children || (parent.children = []))
                                // add node to child array
                                .push(node);
                        } else {
                            // parent is null or missing
                            treeData.push(node);
                        }
                    });

                    $scope.data_flat_node = data;
                    $scope.json = treeData[0];
                    $scope.$apply();

                    $('.row-question').removeClass('active_question_row');
                    $('#question' + $scope.selected_question_one.question_id).addClass('active_question_row');

                    // END Case 01: Old survey is no branching ==> Same case create new branching

                } else {
                    // Case 02: Old survey is branching ==> Draw again old branching
                    // If have more than one old branching question --> Draw again
                    var edit_survey_matrix = $scope.edit_survey_matrix;

                    // result search ***
                    var list_group = [];
                    $scope.group_question.forEach(function (value, index) {
                        var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                        var questionData = [];
                        value.question_list.forEach(function (val, idx) {
                            questionData.push(val);
                        });
                        groupData.question_list = questionData;
                        list_group.push(groupData);
                    });
                    $scope.group_question_result_search = list_group;
                    // END result search ***

                    var branching_data = [];

                    $scope.group_question_result_search.forEach(function (value, index) {
                        value.question_list.forEach(function (val, idx) {
                            var content_qt = val.question_content;
                            if(content_qt.length > 50) {
                                content_qt = content_qt.substring(0, 50) + "...";
                            }
                            var questionType = "";
                            if(val.question_type == 0) {
                                questionType = gettextCatalog.getString('Single choice');
                            } else if(val.question_type == 1) {
                                questionType = gettextCatalog.getString('Multiple choice');
                            } else if(val.question_type == 2) {
                                questionType = gettextCatalog.getString('Input text');
                            }
                            var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                            val.answer_list.forEach(function (awer, ix) {
                                var destinationId = $scope.findDestinationByQuestionIdAnswerId(edit_survey_matrix, val.question_id, awer.answer_id);
                                if(destinationId != undefined && destinationId != null) {
                                    destinationId = destinationId + '';
                                } else {
                                    destinationId = "-1";
                                }
                                if(val.question_type == 2 || val.question_type == "2") {
                                    var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": destinationId};
                                    questionData.answer_list.push(answer);
                                } else {
                                    var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": destinationId};
                                    questionData.answer_list.push(answer);
                                }
                            });

                            // If has_other_answer then add answer_list
                            if(val.has_other_answer) {
                                var destinationId = $scope.findDestinationByQuestionIdAnswerId(edit_survey_matrix, val.question_id, "-1");
                                if(destinationId != undefined && destinationId != null) {
                                    destinationId = destinationId + '';
                                } else {
                                    destinationId = "-1";
                                }
                                var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": destinationId};
                                questionData.answer_list.push(answer);
                            }

                            branching_data.push(questionData);
                        });
                    });

                    $scope.branching_data = branching_data;
                    $scope.selected_question_one = branching_data[0];
                    // List of destination question
                    var selectedQuestionId = $scope.selected_question_one.question_id;
                    var isStartChoose = false;
                    var listQuestionToBranching = [];

                    $scope.group_question.forEach(function(gp) {
                        var listQuestion = [];
                        gp.question_list.forEach(function(qs) {
                            if(qs.question_id == selectedQuestionId) {
                                isStartChoose = true;
                            }

                            if(isStartChoose && qs.question_id !== selectedQuestionId) {
                                listQuestion.push(qs);
                            }
                        });
                        if(listQuestion.length > 0) {
                            var data = {"group": gp.title, "list": listQuestion}
                            listQuestionToBranching.push(data);
                        }
                    });
                    $scope.listQuestionToBranching = listQuestionToBranching;

                    // Update mind map
                    $scope.updateJsonDataForMindMap();
                    $scope.$apply();

                    $('.row-question').removeClass('active_question_row');
                    $('#question' + $scope.selected_question_one.question_id).addClass('active_question_row');
                }
            }

            if($scope.edit_survey_matrix !== undefined && $scope.edit_survey_matrix.length > 0){
                //==============================Branching data =====================================
                /*var list_group = [];
                 res.data.question_group.forEach(function (value, index) {
                 var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                 var questionData = [];
                 value.question_list.forEach(function (val, idx) {
                 questionData.push(val);
                 });
                 groupData.question_list = questionData;
                 list_group.push(groupData);
                 });
                 $scope.group_question = list_group;
                 var branching_data = [];

                 $scope.group_question.forEach(function (value, index) {
                 value.question_list.forEach(function (val, idx) {
                 var content_qt = val.question_content;
                 if(content_qt.length > 50) {
                 content_qt = content_qt.substring(0, 50) + "...";
                 }
                 var questionType = "";
                 if(val.question_type == 0) {
                 questionType = gettextCatalog.getString('Single choice');
                 } else if(val.question_type == 1) {
                 questionType = gettextCatalog.getString('Multiple choice');
                 } else if(val.question_type == 2) {
                 questionType = gettextCatalog.getString('Input text');
                 }
                 var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                 val.answer_list.forEach(function (awer, ix) {
                 var destinationId = $scope.findDestination(res.data.survey_matrix, val.question_id, awer.answer_id);
                 if(destinationId != undefined && destinationId != null) {
                 destinationId = destinationId + '';
                 } else {
                 destinationId = "-1";
                 }

                 if(val.question_type == 2 || val.question_type == "2") {
                 var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": destinationId};
                 questionData.answer_list.push(answer);
                 } else {
                 var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": destinationId};
                 questionData.answer_list.push(answer);
                 }
                 });

                 // If has_other_answer then add answer_list
                 if(val.has_other_answer) {
                 var destinationId = $scope.findDestination(res.data.survey_matrix, val.question_id, "-1");
                 if(destinationId != undefined && destinationId != null) {
                 destinationId = destinationId + '';
                 } else {
                 destinationId = "-1";
                 }

                 var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": destinationId};
                 questionData.answer_list.push(answer);
                 }

                 branching_data.push(questionData);
                 });
                 });

                 $scope.branching_data = branching_data;*/


                //alert("Update mind map: " + JSON.stringify($scope.json));

                /*var levelWidth = [1];
                 var childCount = function(level, n) {
                 if (n.children && n.children.length > 0) {
                 if (levelWidth.length <= level + 1) levelWidth.push(0);

                 levelWidth[level + 1] += n.children.length;
                 n.children.forEach(function(d) {
                 childCount(level + 1, d);
                 });
                 }
                 };
                 childCount(0, $scope.json);
                 var newHeight = d3.max(levelWidth) * 50 + 25;
                 $("svg").height(newHeight);*/
                //==============================END Branching data ==================================


            } else {
                // If haven't one old branching question --> Draw with root node is the first question in prev step
                //alert("If haven't one old branching question --> Draw with root node is the first question in prev step");
                /*$scope.root = null;
                $scope.fileName = "mindMap";
                var jsonData = {};
                var first_group_question = $scope.group_question[0];
                var first_question = first_group_question.question_list[0];
                var first_question_answer_list = first_question.answer_list;

                $scope.questionRootId = first_question.question_id;
                $scope.counterQuestionOnMindmap = 1;
                $scope.questionIdExisting = [(first_question.question_id +"")];

                jsonData.name = first_question.question_content;
                jsonData.children = [];
                first_question_answer_list.forEach(function (val, idx) {
                    var q = {name: val.title};
                    jsonData.children.push(q);
                });

                //====================================Convert data to draw==========================================
                var data = [
                    { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                ];
                first_question_answer_list.forEach(function (val, idx) {
                    data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":first_question.question_content , "parentId":first_question.question_id, "mark_root": 0});
                });
                var dataMap = data.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                data.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.data_flat_node = data;
                $scope.json = treeData[0];
                $scope.$apply();*/
            }

            $scope.isViewConfirm = 0;

        };

        $scope.setBranchAnser = function (question_id, answerId) {
            var check = false;
            if($("#checkbox"+answerId).is(":checked")) {
                check = true;
                $("#select"+answerId).removeAttr("disabled");
            }

            // set lai du lieu
            $scope.branching_data.forEach(function(gp) {
                if(gp.question_id == question_id) {
                    gp.answer_list.forEach(function(qs) {
                        if(qs.answer_id == answerId) {
                            qs.answer_selected = check;
                        }
                    });
                }
            });

        };

        $scope.changeDestinationQuestion = function (question_id, answerId) {
            var destinationId = $("#select" + answerId).val();
            // set lai du lieu
            $scope.branching_data.forEach(function(gp) {
                if(gp.question_id == question_id) {
                    gp.answer_list.forEach(function(qs) {
                        if(qs.answer_id == answerId) {
                            //alert(JSON.stringify($scope.selected_question_one));
                            //alert("===");
                            qs.destination_id = destinationId;
                        }
                    });
                }
            });

            // Update mind map
            $scope.updateJsonDataForMindMap();
        };

        $scope.updateJsonDataForMindMap = function () {
            var first_group_question = $scope.group_question[0];
            var first_question = first_group_question.question_list[0];
            $scope.drawMindMapForBranching(first_question, null, null, 0);
        };

        function recursiveDrawQuestion(questionInput, parentInput, parentIdInput, parentLevel){
            var draw_child = true;

            // $scope.branching_data --> Matrix data
            var surveyType = 1;
            var surveyMatrixList = [];
            var data_flat_node = $scope.branching_data;
            if(data_flat_node.length > 1) {
                // for source question
                for (var i =0; i < data_flat_node.length; i++) {
                    var sourceQuestion = data_flat_node[i];
                    sourceQuestion.answer_list.forEach(function (val) {
                        if(val.destination_id !== undefined && val.destination_id !== "" && val.destination_id !== -1 && val.destination_id !== "-1") {
                            var matrix = {"source_question_id": sourceQuestion.question_id, "answer_id": val.answer_id, "destination_question_id": val.destination_id};
                            surveyMatrixList.push(matrix);
                            surveyType = 2;
                        }

                    });
                }
            }

            var first_question = questionInput;
            var parent = first_question.question_content;
            var parentId = '';
            //var parentLevel = 0;

            var level = parentLevel;

            if(parentInput == undefined || parentIdInput == undefined) {
                // THE ROOT QUESTION(type = 0)
                level = 0;
                parentLevel = level;
                parentId = ''+first_question.question_id;
                $scope.mindmap_level.push(level);
                $scope.data_mindmap_flat.push({ "key":''+first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1, "level": level});

                if($.inArray(first_question.question_id, $scope.existing_node) == -1) {
                    $scope.existing_node.push(first_question.question_id);
                }

            } else {
                parentId = parentIdInput+'_'+first_question.question_id;
                level = level + 1;
                parentLevel = level;

                if($.inArray(first_question.question_id, $scope.existing_node) == -1) {
                    // THE NORMAL QUESTION(type = 0)
                    $scope.mindmap_level.push(level);
                    $scope.data_mindmap_flat.push({ "key":parentIdInput+'_'+first_question.question_id, "name" : first_question.question_content, "type": 0, "parent":parentInput, "parentId":parentIdInput, "mark_root": 0, "level": level});

                    $scope.existing_node.push(first_question.question_id);
                } else {
                    // THE EXISTING QUESTION(type = 2)
                    $scope.mindmap_level.push(level);
                    $scope.data_mindmap_flat.push({ "key":parentIdInput+'_'+first_question.question_id, "name" : first_question.question_content , "type": 2, "parent":parentInput, "parentId":parentIdInput, "mark_root": 0, "level": level});
                    draw_child = false;
                }
            }

            if(draw_child) {
                // The question haven't branching
                var haveBranching = $scope.checkQuestionHaveBranching(first_question.question_id);
                if(!haveBranching) {
                    // Draw next question
                    var nextQuestion = $scope.getNextQuestion(first_question.question_id);
                    if(nextQuestion != null && nextQuestion!= undefined) {
                        recursiveDrawQuestion(nextQuestion, first_question.question_content, parentId, parentLevel);
                    }
                } else {
                    // The list answer of the question
                    var ques_answer_list = first_question.answer_list;
                    // Have other answer then add to list_answer
                    if(first_question.has_other_answer == 1) {
                        var other_anser_add = {"activeFlg": 1, "answer_id": -1, "title": gettextCatalog.getString('Input other answer'), "is_selected": false, "is_correct": 0, "sequence": 0};
                        if(jQuery.inArray( other_anser_add, ques_answer_list ) < 0) {
                            ques_answer_list.push(other_anser_add);
                        }
                    }

                    // Add all answer vào mind map
                    ques_answer_list.forEach(function(answer) {
                        // Draw anwser
                        if(!$scope.checkKeyExisting(parentId+'_'+answer.answer_id)) {
                            // THE ANSWER(type = 1)
                            var levelA = level + 1;
                            $scope.mindmap_level.push(level);

                            var title = gettextCatalog.getString('Input text');
                            if(answer.title !== '' && answer.title !== undefined) {
                                title = answer.title;
                            }
                            $scope.data_mindmap_flat.push({ "key":parentId+'_'+answer.answer_id, "name" : title, "type": 1, "parent":parent, "parentId":parentId, "mark_root": 0, "level": level});

                            var parentA = answer.title;
                            var parentIdA = parentId+'_'+answer.answer_id;

                            if($scope.findDestination(first_question.question_id , answer.answer_id) >= 0) {
                                if($scope.findDestination(first_question.question_id , answer.answer_id) == 0) {
                                    // Terminate survey!( type = -1)
                                    $scope.mindmap_level.push(levelA);
                                    $scope.data_mindmap_flat.push({ "key":parentId+'_'+answer.answer_id+'_0', "name" : gettextCatalog.getString('Terminate the survey'), "type": -1, "parent":parentA, "parentId":parentIdA, "mark_root": 0, "level": levelA});
                                } else {
                                    // (Question, Answer) có Destination --> Draw Destination question
                                    var destinationQuestion = $scope.findQuestionById($scope.findDestination(first_question.question_id , answer.answer_id));
                                    if(destinationQuestion != null && destinationQuestion!= undefined) {
                                        recursiveDrawQuestion(destinationQuestion, parentA, parentIdA, levelA);
                                    }
                                }
                            } else {
                                // Draw next question
                                var nextQuestion = $scope.getNextQuestion(first_question.question_id);
                                if(nextQuestion != null && nextQuestion!= undefined) {
                                    recursiveDrawQuestion(nextQuestion, parentA, parentIdA, levelA);
                                }
                            }
                        }
                    });
                }
            }

        }

        $scope.checkKeyExisting  = function (key) {
            var result = false;
            $scope.data_mindmap_flat.forEach(function (element) {
                if(element.key == key) {
                    result = true;
                }
            });
            return result;
        }

        $scope.drawMindMapForBranching  = function (questionInput, parentInput, parentIdInput, level) {
            $scope.data_mindmap_flat = [];
            $scope.mindmap_level = [];
            $scope.existing_node = [];
            recursiveDrawQuestion(questionInput, parentInput, parentIdInput, level);
            $scope.data_flat_node = $scope.data_mindmap_flat;
            $scope.json = $scope.convertFlatToJsonData($scope.data_mindmap_flat);
        }

        $scope.getNextQuestion = function (questionId) {
            var result = null;
            var isQuestion = false;
            $scope.group_question.forEach(function (groupData) {
                groupData.question_list.forEach(function (question) {
                    if(isQuestion && result == null) {
                        result = question;
                    }
                    if(question.question_id == questionId) {
                        isQuestion = true;
                    }
                });
            });
            return result;
        }

        $scope.convertFlatToJsonData = function (data) {
            var dataMap = data.reduce(function(map, node) {
                map[node.key] = node;
                return map;
            }, {});

            var treeData = [];
            data.forEach(function(node) {
                // add to parent
                var parent = dataMap[node.parentId];
                if (parent) {
                    // create child array if it doesn't exist
                    (parent.children || (parent.children = []))
                        // add node to child array
                        .push(node);
                } else {
                    // parent is null or missing
                    treeData.push(node);
                }
            });

            return treeData[0];
        }

        $scope.findQuestionById = function (questionId) {
            var result = null;
            $scope.group_question.forEach(function (groupData) {
                groupData.question_list.forEach(function (question) {
                    if(question.question_id == questionId) {
                        result = question;
                    }
                });
            });
            return result;
        }

        $scope.checkQuestionHaveBranching = function (questionId) {
            var surveyType = 1;
            var surveyMatrixList = [];
            var data_flat_node = $scope.branching_data;
            if(data_flat_node.length > 1) {
                // for source question
                for (var i =0; i < data_flat_node.length; i++) {
                    var sourceQuestion = data_flat_node[i];
                    sourceQuestion.answer_list.forEach(function (val) {
                        if(val.destination_id !== undefined && val.destination_id !== "" && val.destination_id !== -1 && val.destination_id !== "-1") {
                            var matrix = {"source_question_id": sourceQuestion.question_id, "answer_id": val.answer_id, "destination_question_id": val.destination_id};
                            surveyMatrixList.push(matrix);
                            surveyType = 2;
                        }

                    });
                }
            }

            var result = false;
            surveyMatrixList.forEach(function(matrix) {
                if(matrix.source_question_id == questionId) {
                    result = true;
                }
            });

            return result;
        }

        $scope.findDestination = function (questionId, answerId) {
            var surveyType = 1;
            var surveyMatrixList = [];
            var data_flat_node = $scope.branching_data;
            if(data_flat_node.length > 1) {
                // for source question
                for (var i =0; i < data_flat_node.length; i++) {
                    var sourceQuestion = data_flat_node[i];
                    sourceQuestion.answer_list.forEach(function (val) {
                        if(val.destination_id !== undefined && val.destination_id !== "" && val.destination_id !== -1 && val.destination_id !== "-1") {
                            var matrix = {"source_question_id": sourceQuestion.question_id, "answer_id": val.answer_id, "destination_question_id": val.destination_id};
                            surveyMatrixList.push(matrix);
                            surveyType = 2;
                        }
                    });
                }
            }

            var destinationId = -1;
            surveyMatrixList.forEach(function(matrix) {
                if(matrix.source_question_id == questionId && matrix.answer_id == answerId) {
                    destinationId = matrix.destination_question_id;
                }
            });

            return destinationId;
        }

        $scope.chooseQuestion = function (group, question) {
            // Selected question
            $scope.selectedQuestionBranch = question;
            var questionContent = "";
            if($scope.selectedQuestionBranch.question_content.length > 50) {
                questionContent = $scope.selectedQuestionBranch.question_content.substring(0, 50) + "...";
            } else {
                questionContent = $scope.selectedQuestionBranch.question_content;
            }
            $scope.questionContent = questionContent;
            $scope.answerListOfSelectedQuestion = question.answer_list;

            // List of destination question
            var selectedQuestionId = question.question_id;
            var isStartChoose = false;
            var listQuestionToBranching = [];

            $scope.group_question.forEach(function(gp) {
                var listQuestion = [];
                gp.question_list.forEach(function(qs) {
                    if(qs.question_id == selectedQuestionId) {
                        isStartChoose = true;
                    }

                    if(isStartChoose && qs.question_id !== selectedQuestionId) {
                        listQuestion.push(qs);
                    }
                });
                if(listQuestion.length > 0) {
                    var data = {"group": gp.title, "list": listQuestion}
                    listQuestionToBranching.push(data);
                }
            });
            $scope.listQuestionToBranching = listQuestionToBranching;
        };

        /**
         * Draw mind map when edit
         */
        $scope.drawMindmapEdit = function () {
            if($scope.edit_survey_matrix !== undefined && $scope.edit_survey_matrix.length > 0){
                // If have more than one old branching question --> Draw again
                var edit_survey_matrix = $scope.edit_survey_matrix;
                var rootQuestionId = $scope.edit_survey_matrix[0].source_question_id;

                // Tạo flat_data từ tất cả câu hỏi cũ
                var old_flat_data_survey = $scope.old_flat_data_survey;
                var first_question_draw;
                old_flat_data_survey.forEach(function(group) {
                    var question_list = group.question_list;
                    question_list.forEach(function(question) {
                        if(question.question_id == rootQuestionId) {
                            first_question_draw = question;
                        }
                    });
                });

                // CASE INIT
                $scope.root = null;
                $scope.fileName = "mindMap";
                var jsonData = {};
                var first_group_question = $scope.group_question[0];
                var first_question = first_question_draw;
                var first_question_answer_list = first_question.answer_list;

                $scope.questionRootId = first_question.question_id;
                $scope.counterQuestionOnMindmap = 1;
                $scope.questionIdExisting = [(first_question.question_id +"")];

                jsonData.name = first_question.question_content;
                jsonData.children = [];
                first_question_answer_list.forEach(function (val, idx) {
                    var q = {name: val.title};
                    jsonData.children.push(q);
                });

                //====================================Convert data to draw==========================================
                var data = [
                    { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                ];
                first_question_answer_list.forEach(function (val, idx) {
                    data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":first_question.question_content , "parentId":first_question.question_id, "mark_root": 0});
                });

                while (edit_survey_matrix.length > 0){
                    edit_survey_matrix.forEach(function(survey_matrix) {

                        // source && destination existing then remove
                        if ($.inArray((survey_matrix.source_question_id+""), $scope.questionIdExisting) >= 0
                            && $.inArray((survey_matrix.destination_question_id+""), $scope.questionIdExisting) >= 0) {
                            edit_survey_matrix.remove(survey_matrix);
                        }

                        //
                        if ($.inArray((survey_matrix.source_question_id+""), $scope.questionIdExisting) >= 0
                            && $.inArray((survey_matrix.destination_question_id+""), $scope.questionIdExisting) < 0) {
                            // Tạo node: Destination
                            var destinationId = survey_matrix.destination_question_id;
                            var destinationQuestion;
                            old_flat_data_survey.forEach(function(group) {
                                var question_list = group.question_list;
                                question_list.forEach(function(question) {
                                    if(question.question_id == destinationId) {
                                        destinationQuestion = question;
                                    }
                                });
                            });
                            var destination_answer_list = destinationQuestion.answer_list;

                            var destination_data = [
                                { "key":destinationQuestion.question_id, "name" : destinationQuestion.question_content, "type": 0, "parent":"", "parentId":survey_matrix.answer_id, "mark_root": 0},
                            ];
                            destination_answer_list.forEach(function (val, idx) {
                                destination_data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":destinationQuestion.question_content , "parentId":destinationQuestion.question_id, "mark_root": 0});
                            });

                            var indexOfkey = edit_survey_matrix.indexOf(survey_matrix);
                            if(indexOfkey != -1) {
                                edit_survey_matrix.splice(indexOfkey, 1);
                                $scope.questionIdExisting.push(survey_matrix.destination_question_id+"");
                            }
                            //edit_survey_matrix.remove(survey_matrix);

                            //
                            if(destination_data.length >0) {
                                destination_data.forEach(function(d) {
                                    data.push(d);
                                });
                            }
                        }
                    });
                }

                var dataMap = data.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                data.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.data_flat_node = data;
                $scope.json = treeData[0];
                $scope.isViewConfirm = 0;
                $scope.$apply();

            } else {
                // If haven't one old branching question --> Draw with root node is the first question in prev step
                //alert("If haven't one old branching question --> Draw with root node is the first question in prev step");
                $scope.root = null;
                $scope.fileName = "mindMap";
                var jsonData = {};
                var first_group_question = $scope.group_question[0];
                var first_question = first_group_question.question_list[0];
                var first_question_answer_list = first_question.answer_list;

                $scope.questionRootId = first_question.question_id;
                $scope.counterQuestionOnMindmap = 1;
                $scope.questionIdExisting = [(first_question.question_id +"")];

                jsonData.name = first_question.question_content;
                jsonData.children = [];
                first_question_answer_list.forEach(function (val, idx) {
                    var q = {name: val.title};
                    jsonData.children.push(q);
                });

                //====================================Convert data to draw==========================================
                var data = [
                    { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "mark_root": 1},
                ];
                first_question_answer_list.forEach(function (val, idx) {
                    data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":first_question.question_content , "parentId":first_question.question_id, "mark_root": 0});
                });
                var dataMap = data.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                data.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.data_flat_node = data;
                $scope.json = treeData[0];
                $scope.$apply();
            }

            $scope.isViewConfirm = 0;
        };

        $scope.isQuestionBranching = function () {
            var data_flat_node = $scope.data_flat_node;
            var counter = 0;
            if(data_flat_node.length > 1) {
                var convertData = [];
                for (var i =0; i < data_flat_node.length; i++) {
                    if( data_flat_node[i].type == 0) {
                        counter = counter + 1;
                    }
                }
            }

            if(counter >= 2) {
                return 1;
            } else {
                return 0;
            }
        };


        $scope.searchQuestionOnGroup = function () {
            $scope.selected_question_one = {};
        };

        /**
         * Draw mind map confirm
         */
        $scope.drawMindmapConfirm = function () {
            //Mark screen confirm
            $scope.isViewConfirm = 1;
            var data_flat_node = $scope.data_flat_node;
            $scope.confirmType = false;
            if(data_flat_node.length > 1 && $scope.isQuestionBranching() == 1) {
                $scope.confirmType = true;
                // Convert node format
                var convertData = [];
                for (var i =0; i < data_flat_node.length; i++) {
                    if( data_flat_node[i].parent == undefined || data_flat_node[i].parent == null) {
                        var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": 0, "mark_root": data_flat_node[i].mark_root};
                        convertData.push(nodeData);
                    }else{
                        var parent = null;
                        var pO = data_flat_node[i].parent;
                        if(typeof data_flat_node[i].parent !== 'string') {
                            parent = data_flat_node[i].parent.name;
                        }
                        var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": data_flat_node[i].type, "parent": "" + parent , "parentId": data_flat_node[i].parentId, "mark_root": data_flat_node[i].mark_root};
                        convertData.push(nodeData);
                    }
                }

                var dataMap = convertData.reduce(function(map, node) {
                    map[node.key] = node;
                    return map;
                }, {});

                var treeData = [];
                convertData.forEach(function(node) {
                    // add to parent
                    var parent = dataMap[node.parentId];
                    if (parent) {
                        // create child array if it doesn't exist
                        (parent.children || (parent.children = []))
                            // add node to child array
                            .push(node);
                    } else {
                        // parent is null or missing
                        treeData.push(node);
                    }
                });

                $scope.json = treeData[0];
            } else {
                $scope.confirmType = false;
            }
            $scope.$apply();

        };

        $scope.searchIndexQuestion = function (beforeQuestionId) {
            var indexOfCurrentQuestion = 0;
            var ressult = 0;
            $scope.group_question.forEach(function (value, index) {
                value.question_list.forEach(function (val, idx) {
                    if(val.question_id == beforeQuestionId) {
                        ressult = indexOfCurrentQuestion;
                    }
                    indexOfCurrentQuestion = indexOfCurrentQuestion + 1;
                });
            });

            var qList = {question_list: []};
            var orderQuestion = 0;
            var indexSelectQuestion = 0;
            $scope.group_question.forEach(function (value, index) {
                value.question_list.forEach(function (val, idx) {
                    //alert(indexSelectQuestion +" : "+ ressult + " |  " + (val.question_id + "") + " in " +JSON.stringify($scope.questionIdExisting)+ " | " + ($.inArray((val.question_id + ""), $scope.questionIdExisting) == -1));
                    if(indexSelectQuestion > ressult && ($.inArray((val.question_id + ""), $scope.questionIdExisting) == -1)) {
                        var q = {question_id: null, required_flg: null, order: (orderQuestion + 1)};
                        if (val.required == true) {
                            val.required_flg = 1;
                        } else {
                            val.required_flg = 0;
                        }
                        q.question_id = val.question_id;
                        q.question_content = val.question_content;
                        q.question_sequence = idx;
                        q.question_type = val.question_type;
                        q.answer_list = val.answer_list;
                        q.required_flg = val.required_flg;
                        if($scope.questionRootId !== q.question_id) {
                            qList.question_list.push(q);
                        }
                    }
                    indexSelectQuestion = indexSelectQuestion + 1;
                });
            });

            if(qList.question_list.length >0 ){
                $scope.list_question_to_choose = qList.question_list;
                $scope.$apply();
            } else {
                $scope.list_question_to_choose = [];
                $scope.$apply();
            }

        };

        // function question in survey aaaa
        $scope.chooseQuestionBranching = function (group, question) {
            $('.row-question').removeClass('active_question_row');
            $('#question' + question.question_id).addClass('active_question_row');

            $scope.the_selected_question = question;

            var branching_data = $scope.branching_data;
            var selected_question_one;
            branching_data.forEach(function(dt) {
                if(dt.question_id == question.question_id) {
                    selected_question_one = dt;
                }
            });

            $scope.selected_question_one = selected_question_one;

            // List of destination question
            var selectedQuestionId = question.question_id;
            var isStartChoose = false;
            var listQuestionToBranching = [];

            $scope.group_question.forEach(function(gp) {
                var listQuestion = [];
                gp.question_list.forEach(function(qs) {
                    if(qs.question_id == selectedQuestionId) {
                        isStartChoose = true;
                    }

                    if(isStartChoose && qs.question_id !== selectedQuestionId) {
                        listQuestion.push(qs);
                    }
                });
                if(listQuestion.length > 0) {
                    var data = {"group": gp.title, "list": listQuestion}
                    listQuestionToBranching.push(data);
                }
            });
            $scope.listQuestionToBranching = listQuestionToBranching;

        };

        $scope.openPopupChooseQuestion = function (d) {
            var n = d;
            $scope.currentNodeAction = d;
            // List question to choose
            if($scope.list_question_to_choose != undefined) {
                // Chi lay cau hoi sau currentNode
                var list_question_to_choose = $scope.list_question_to_choose;
                var beforeQuestionId = $scope.currentNodeAction.parentId;

                $scope.searchIndexQuestion(beforeQuestionId);
                if($scope.list_question_to_choose != undefined && $scope.list_question_to_choose.length > 0) {
                    $('.actions > ul > li:first-child').attr('style', 'display:auto');
                    $('#choose-question-branching-modal').modal('show');
                }
            } else if($scope.counterQuestionOnMindmap == 1) {
                // First Load
                var list_question_to_choose;
                var qList = {question_list: []};
                var orderQuestion = 0;
                $scope.group_question.forEach(function (value, index) {
                    value.question_list.forEach(function (val, idx) {
                        var q = {question_id: null, required_flg: null, order: (orderQuestion + 1)};
                        if (val.required == true) {
                            val.required_flg = 1;
                        } else {
                            val.required_flg = 0;
                        }
                        q.question_id = val.question_id;
                        q.question_content = val.question_content;
                        q.question_sequence = idx;
                        q.question_type = val.question_type;
                        q.answer_list = val.answer_list;
                        q.required_flg = val.required_flg;
                        if($scope.questionRootId !== q.question_id) {
                            qList.question_list.push(q);
                        }

                    });
                });

                if(qList.question_list.length >0 ){
                    $scope.list_question_to_choose = qList.question_list;
                    $scope.$apply();
                    $('.actions > ul > li:first-child').attr('style', 'display:auto');
                    $('#choose-question-branching-modal').modal('show');
                }
            }
        };

        // Change question branching
        $scope.changeQuestionBranching = function () {
            $scope.counterQuestionOnMindmap = $scope.counterQuestionOnMindmap + 1;

            var currentNodeAction = $scope.currentNodeAction;
            // Id of question Add
            var addedQuestionId = $scope.md_select_question_branching;
            // Current mind map
            var saveData = serializeData($scope.root);
            // Additional Questions and Answers
            var newQuestionAnswer = getChildsById($scope.md_select_question_branching);
            saveData.children.push(newQuestionAnswer);

            // Question Id Existing
            $scope.questionIdExisting.push(addedQuestionId);

            // Flat mind map data
            var data_flat_node = $scope.data_flat_node;
            // Search the current node in flat data
            var currentNodeActionFlat;
            for (var i =0; i < data_flat_node.length; i++) {
                if (data_flat_node[i].key == currentNodeAction.key) {
                    currentNodeActionFlat = data_flat_node[i];
                }
            }
            // Add the question, answers to the flat data
            var listNewNodeFlat = getNewNoteFlat(currentNodeAction, addedQuestionId, currentNodeActionFlat);
            for (var i =0; i < listNewNodeFlat.length; i++) {
                data_flat_node.push(listNewNodeFlat[i]);
            }

            // Convert node format
            var convertData = [];
            for (var i =0; i < data_flat_node.length; i++) {
                if( data_flat_node[i].parent == undefined || data_flat_node[i].parent == null) {
                    var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": 0, "mark_root": data_flat_node[i].mark_root};
                    convertData.push(nodeData);
                }else{
                    var parent = null;
                    var pO = data_flat_node[i].parent;
                    if(typeof data_flat_node[i].parent !== 'string') {
                        parent = data_flat_node[i].parent.name;
                    } else {
                        parent = data_flat_node[i].parent;
                    }
                    var nodeData = { "key": data_flat_node[i].key, "name" :  data_flat_node[i].name, "type": data_flat_node[i].type, "parent": "" + parent , "parentId": data_flat_node[i].parentId, "mark_root": data_flat_node[i].mark_root};
                    convertData.push(nodeData);
                }
            }

            var dataMap = convertData.reduce(function(map, node) {
                map[node.key] = node;
                return map;
            }, {});

            var treeData = [];
            convertData.forEach(function(node) {
                // add to parent
                var parent = dataMap[node.parentId];
                if (parent) {
                    // create child array if it doesn't exist
                    (parent.children || (parent.children = []))
                        // add node to child array
                        .push(node);
                } else {
                    // parent is null or missing
                    treeData.push(node);
                }
            });

            $scope.json = treeData[0];

            // DELETE the question in list question
            var list_question_to_choose = $scope.list_question_to_choose;
            for (var i =0; i < list_question_to_choose.length; i++) {
                if (list_question_to_choose[i].question_id == $scope.md_select_question_branching) {
                    list_question_to_choose.splice(i, 1);
                }
            }

            $('#choose-question-branching-modal').modal('hide');
        };

        function getQuestionById(id) {
            var list_question_to_choose = $scope.list_question_to_choose;
            for (var i =0; i < list_question_to_choose.length; i++) {
                if (list_question_to_choose[i].question_id == id) {
                    return list_question_to_choose[i];
                }
            }
        }

        function getChildsById(id) {
            var list_question_to_choose = $scope.list_question_to_choose;
            var qn ;
            for (var i =0; i < list_question_to_choose.length; i++) {
                if (list_question_to_choose[i].question_id == id) {
                    qn = list_question_to_choose[i];
                }
            }

            var res = {
                "name": qn.question_content,
                "children": []
            }

            var lsAnswer = qn.answer_list;
            for (var i =0; i < lsAnswer.length; i++) {
                res.children.push({"name": lsAnswer[i].title});
            }
            return res;

        }

        function getNewNoteFlat(node, id, currentNodeActionFlat) {
            var list_question_to_choose = $scope.list_question_to_choose;
            var first_question ;
            for (var i =0; i < list_question_to_choose.length; i++) {
                if (list_question_to_choose[i].question_id == id) {
                    first_question = list_question_to_choose[i];
                }
            }

            var first_question_answer_list = first_question.answer_list;

            //==============================================================================
            // Kieu du lieu
            var data = [
                { "key":first_question.question_id, "name" : first_question.question_content, "type": 0, "parent":currentNodeActionFlat.name , "parentId":currentNodeActionFlat.key, "mark_root": 0},
            ];
            first_question_answer_list.forEach(function (val, idx) {
                data.push({ "key":val.answer_id, "name" : val.title, "type": 1, "parent":first_question.question_content , "parentId":first_question.question_id, "mark_root": 0});
            });
            return data;
        }

        /**
         * Create new survey
         */
        $scope.create = function () {
            var group = [];
            var data = {};

            var surveyType = 1;
            var surveyMatrixList = [];
            if($scope.checkedBranchingSurvey) {
                var data_flat_node = $scope.branching_data;
                if(data_flat_node.length > 1) {
                    // for source question
                    for (var i =0; i < data_flat_node.length; i++) {
                        var sourceQuestion = data_flat_node[i];
                        sourceQuestion.answer_list.forEach(function (val) {
                            if(val.destination_id !== undefined && val.destination_id !== "" && val.destination_id !== -1 && val.destination_id !== "-1") {
                                var destination_id = null;
                                var answer_id = val.answer_id;
                                /*if(answer_id == -1) {
                                    answer_id = 0;
                                }*/
                                if (typeof val.destination_id === 'string' || val.destination_id instanceof String){
                                    // it's a string
                                    destination_id = parseInt(val.destination_id);
                                } else {
                                    // it's something else
                                    destination_id = val.destination_id;
                                }
                                var matrix = {"source_question_id": sourceQuestion.question_id, "answer_id": answer_id, "destination_question_id": destination_id};
                                surveyMatrixList.push(matrix);
                                surveyType = 2;
                            }

                        });
                    }
                }
            }

            $scope.group_question.forEach(function (value, index) {
                var qList = {title: null, question_list: []};
                value.question_list.forEach(function (val, idx) {
                    var q = {question_id: null, required_flg: null};
                    if (val.required == true) {
                        val.required_flg = 1;
                    } else {
                        val.required_flg = 0;
                    }
                    q.question_id = val.question_id;
                    q.question_content = val.question_content;
                    q.question_sequence = idx;
                    q.question_type = val.question_type;

                    //q.answer_list = val.answer_list;
                    var aList = [];
                    val.answer_list.forEach(function (ans, jdx) {
                        if (ans.answer_id > 0) {
                            aList.push(ans);
                        }
                    });
                    q.answer_list = aList;

                    q.required_flg = val.required_flg;
                    qList.question_list.push(q);
                });
                qList.title = value.title;
                if (value.group_id != null) {
                    qList.group_id = value.group_id;
                }
                qList.group_sequence = index;
                group.push(qList);
            });
            if ($scope.surveyActive == true) {
                $scope.surveyActive = 1;
            } else {
                $scope.surveyActive = 0;
            }

            // EDIT SURVEY
            if ($scope.survey_id != null) {
                data = {
                    hosp_code: $scope.hospital.hosp_code,
                    department_code: $scope.selectedDept,
                    survey_title: $scope.item.survey_title,
                    survey_id: $scope.survey_id,
                    description: $scope.item.description,
                    use_flg: $scope.surveyActive,
                    question_group: group,
                    //survey_matrix: [],
                    survey_matrix: surveyMatrixList,
                    survey_type: surveyType
                };

                SurveysService.EditSurvey(data, function (res) {
                    if (res.status == 1) {
                        var deptArr = [];
                        var itemLocal = localStorageService.get($cookieStore.get('globals').currentUser.username + 'survey');
                        SurveysService.GetSurveyByDept(data.department_code, function (res) {
                            if (res.status == 1) {
                                res.data.survey_list.forEach(function (value) {
                                    if ($.inArray(value.id, itemLocal) == -1) {
                                        value.show_flg = 1;
                                        deptArr.push(value);
                                    }
                                });
                                deptArr.sort(function (a, b) {
                                    return b.use_flg - a.use_flg;
                                });
                                $timeout(function () {
                                    $scope.dept[$scope.parent_index].survey = deptArr;
                                }, 100)
                            } else if (res.status == 401) {
                                $cookieStore.remove('globals');
                                $location.path('/login').search({code: localStorageService.get('hosp_code')});
                            } else {
                                $location.path('/');
                            }
                        });
                        $scope.changeStep = 'changed';
                    } else {
                        $.gritter.add({
                            title: gettextCatalog.getString('Can\'t save this survey.'),
                            text: gettextCatalog.getString('Please, check again.'),
                            class_name: 'with-icon times-circle warning'
                        });
                        $scope.changeStep = 'stop'
                    }
                });
            } else {
                // CREATE NEW SURVEY
                data = {
                    hosp_code: $scope.hospital.hosp_code,
                    department_code: $scope.selectedDept,
                    survey_title: $scope.item.survey_title,
                    description: $scope.item.description,
                    use_flg: $scope.surveyActive,
                    question_group: group,
                    survey_matrix: surveyMatrixList,
                    survey_type: 1
                };

                //data.draw_data = "";
                data.survey_type = surveyType;
                if(surveyMatrixList.length > 0) {
                    data.survey_matrix = surveyMatrixList;
                }

                SurveysService.CreateSurvey(data, function (res) {
                    if (res.status == 1) {
                        $scope.changeStep = 'changed';
                    } else if (res.status == 401) {
                        $cookieStore.remove('globals');
                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                        $scope.$apply();
                    } else {
                        $.gritter.add({
                            title: gettextCatalog.getString('Can\'t save this survey.'),
                            text: gettextCatalog.getString('Please, check again.'),
                            class_name: 'with-icon times-circle warning'
                        });
                        $scope.changeStep = 'stop';
                    }
                });
            }
        };

        $scope.edit = function (survey, pIdx) {
            $scope.s_department = null;
            $scope.s_question = null;
            $scope.parent_index = pIdx;
            SurveysService.GetDetailSurvey(survey.id, function (res) {
                if (res.status == 1) {
                    //
                    if(res.data.survey_type !== undefined) {
                        $scope.edit_survey_type = res.data.survey_type;
                        $scope.edit_survey_matrix = res.data.survey_matrix;

                        $scope.old_flat_data_survey = res.data.question_group;

                        if(res.data.survey_type == 2) {
                            $scope.checkedBranchingSurvey = true;
                            $scope.saved_survey_matrix = res.data.survey_matrix;
                        } else {
                            $scope.checkedBranchingSurvey = false;
                            $scope.saved_survey_matrix = [];
                        }
                        $scope.old_survey_type = res.data.survey_type;

                        //
                        $scope.branching_data = null;
                    }

                    res.data.question_group.forEach(function (val) {
                        val.active = 0;
                        val.question_list.forEach(function (vl) {
                            vl.selected = false;
                            vl.required = false;
                            vl.actived = false;
                        })
                    });
                    if (res.data.use_flg == 1) {
                        $scope.surveyActive = true;
                    } else {
                        $scope.surveyActive = false;
                    }
                    $scope.survey_id = res.data.survey_id;
                    $scope.selectedDept = res.data.department_code;
                    $scope.group_question = res.data.question_group;
                    $scope.item = res.data;
                } else if (res.status == 401) {
                    $cookieStore.remove('globals');
                    $location.path('/login').search({code: localStorageService.get('hosp_code')});
                } else {
                    $location.path('/');
                }
            });
            $('#edit-survey-title').text($scope.item.survey_title);
            $(".wizard-basic").steps('reset');
            $.each($('.wizard-basic .steps ul li'), function () {
                if ($(this).hasClass('done')) {
                    $(this).removeClass('done');
                    $(this).addClass('disabled');
                }
            });
            $('.actions > ul > li:first-child').attr('style', 'display:auto');
            $('#edit-survey-modal').modal('show');
        };

        /**
         * Delete survey
         * @param survey
         * @param pIdx
         * @param idx
         */
        $scope.confirmDeleteSurvey = function (survey, pIdx, idx) {
            $scope.confirm_delete_survey = survey;
            $scope.confirm_delete_pIdx = pIdx;
            $scope.confirm_delete_idx = idx;

            $('#confirm_delete_survey_form').modal('show');
        };
        $scope.deleteSurvey = function () {
            var survey = $scope.confirm_delete_survey;
            var pIdx = $scope.confirm_delete_pIdx;
            var idx = $scope.confirm_delete_idx;

            SurveysService.DeleteSurvey(survey.id, function (res) {
                if (res.status == 1) {
                    $.gritter.add({
                        title: gettextCatalog.getString('Delete'),
                        text: survey.survey_title + ' ' + gettextCatalog.getString(' was deleted.'),
                        class_name: 'with-icon times-circle success'
                    });
                    $scope.dept[pIdx].survey.splice(idx, 1);
                } else {
                    $.gritter.add({
                        title: gettextCatalog.getString('Can\'t delete this survey.'),
                        text: gettextCatalog.getString('Please, check again.'),
                        class_name: 'with-icon times-circle danger'
                    });
                }
            });

            $('#confirm_delete_survey_form').modal('hide');
        };
        $scope.delete = function (survey, pIdx, idx) {
            SurveysService.DeleteSurvey(survey.id, function (res) {
                if (res.status == 1) {
                    $.gritter.add({
                        title: gettextCatalog.getString('Delete'),
                        text: survey.survey_title + ' ' + gettextCatalog.getString(' was deleted.'),
                        class_name: 'with-icon times-circle success'
                    });
                    $scope.dept[pIdx].survey.splice(idx, 1);
                } else {
                    $.gritter.add({
                        title: gettextCatalog.getString('Can\'t delete this survey.'),
                        text: gettextCatalog.getString('Please, check again.'),
                        class_name: 'with-icon times-circle danger'
                    });
                }
            });
        };

        $scope.home = function () {
            $location.path('/');
        };

        $scope.findDestinationByQuestionIdAnswerId = function (surveyMatrix, questionId, answerId) {
            var result = -1;
            if(surveyMatrix !== undefined && surveyMatrix.length) {
                surveyMatrix.forEach(function (matrix, index) {
                    if(matrix.source_question_id == questionId && matrix.answer_id == answerId) {
                        //alert("x " + matrix.destination_question_id);
                        result = matrix.destination_question_id;
                    }
                });
            }
            return result;
        }

        /**
         * Preview survey
         * @param survey
         */
        $scope.preview = function (survey) {
            if (typeof (survey.id) != 'undefined') {
                SurveysService.GetDetailSurvey(survey.id, function (res) {
                    // Survey branching?
                    var isBranching = false;
                    $scope.root = null;
                    $scope.fileName = "mindMap";
                    var jsonData = {};
                    if(res.data.survey_matrix !== undefined && res.data.survey_matrix.length) {
                        isBranching = true;

                        //==============================Branching data =====================================
                        var list_group = [];
                        res.data.question_group.forEach(function (value, index) {
                            var groupData = {"group_id": value.group_id, "title": value.title, "group_sequence": value.group_sequence};
                            var questionData = [];
                            value.question_list.forEach(function (val, idx) {
                                questionData.push(val);
                            });
                            groupData.question_list = questionData;
                            list_group.push(groupData);
                        });
                        $scope.group_question = list_group;
                        var branching_data = [];

                        $scope.group_question.forEach(function (value, index) {
                            value.question_list.forEach(function (val, idx) {
                                var content_qt = val.question_content;
                                if(content_qt.length > 50) {
                                    content_qt = content_qt.substring(0, 50) + "...";
                                }
                                var questionType = "";
                                if(val.question_type == 0) {
                                    questionType = gettextCatalog.getString('Single choice');
                                } else if(val.question_type == 1) {
                                    questionType = gettextCatalog.getString('Multiple choice');
                                } else if(val.question_type == 2) {
                                    questionType = gettextCatalog.getString('Input text');
                                }
                                var questionData = {"question_id": val.question_id, "question_content": content_qt, "answer_list":[], "type": questionType};
                                val.answer_list.forEach(function (awer, ix) {
                                    var destinationId = $scope.findDestinationByQuestionIdAnswerId(res.data.survey_matrix, val.question_id, awer.answer_id);
                                    if(destinationId != undefined && destinationId != null) {
                                        destinationId = destinationId + '';
                                    } else {
                                        destinationId = "-1";
                                    }

                                    if(val.question_type == 2 || val.question_type == "2") {
                                        var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": gettextCatalog.getString('Input text'), "destination_id": destinationId};
                                        questionData.answer_list.push(answer);
                                    } else {
                                        var answer = {"answer_selected": false, "answer_id": awer.answer_id, "title": awer.title, "destination_id": destinationId};
                                        questionData.answer_list.push(answer);
                                    }
                                });

                                // If has_other_answer then add answer_list
                                if(val.has_other_answer) {
                                    var destinationId = $scope.findDestinationByQuestionIdAnswerId(res.data.survey_matrix, val.question_id, "-1");
                                    if(destinationId != undefined && destinationId != null) {
                                        destinationId = destinationId + '';
                                    } else {
                                        destinationId = "-1";
                                    }

                                    var answer = {"answer_selected": false, "answer_id": -1, "title": gettextCatalog.getString('Other'), "destination_id": destinationId};
                                    questionData.answer_list.push(answer);
                                }

                                branching_data.push(questionData);
                            });
                        });

                        $scope.branching_data = branching_data;

                        // Update mind map
                        $scope.updateJsonDataForMindMap();

                        /*var levelWidth = [1];
                        var childCount = function(level, n) {
                            if (n.children && n.children.length > 0) {
                                if (levelWidth.length <= level + 1) levelWidth.push(0);

                                levelWidth[level + 1] += n.children.length;
                                n.children.forEach(function(d) {
                                    childCount(level + 1, d);
                                });
                            }
                        };
                        childCount(0, $scope.json);
                        var newHeight = d3.max(levelWidth) * 50 + 25;
                        $("svg").height(newHeight);*/
                        //==============================END Branching data ==================================

                    }
                    $scope.isBranching = isBranching;

                    if (res.status == 1) {
                        res.data.question_group.forEach(function (val) {
                            val.active = 0;
                            val.question_list.forEach(function (vl) {
                                vl.selected = false;
                                vl.required = false;
                                vl.actived = false;
                            })
                        });
                        if (res.data.use_flg == 1) {
                            $scope.surveyActive = true;
                        } else {
                            $scope.surveyActive = false;
                        }
                        $.each($scope.departmentList, function (index, value) {
                            if (res.data.department_code == value.department_code) {
                                res.data.department_name = value.department_name;
                            }
                        });
                        $scope.group_question = res.data.question_group;
                        $scope.preview_item = res.data;
                    } else if (res.status == 401) {
                        $cookieStore.remove('globals');
                        $location.path('/login').search({code: localStorageService.get('hosp_code')});
                    } else {
                        $location.path('/');
                    }
                });
            } else {
                $scope.preview_item = $scope.item;
            }

            $('#preview-survey-title').text($scope.preview_item.survey_title);
            $('#preview-survey-popup').modal('show');

            var modal= document.getElementById('loading');
            modal.style.display = "none";
        }

        $scope.closePopup = function () {
            $('#edit-survey-modal').css('overflow-y', 'auto');
            $('#question-popup').modal('hide');
        };

        $scope.exportPdf = function (item) {
            $('#export_survey_to_pdf').hide();
            $('#loading_icon').show();
            var hospitalObj = localStorageService.get('hospitalObj');
            var fontDefault = null;
            var fontFlg = 1;

            if (hospitalObj.data.locale.toLowerCase() == 'ja') {
                fontFlg = 2;
                fontDefault = 'MS PGothic';
            } else {
                fontFlg = 1;
                fontDefault = 'Times New Roman';
            }
            $.each($scope.departmentList, function (index, value) {
                if (value.department_code == $scope.selectedDept) {
                    $scope.department_name = value.department_name;
                }
            });

            if (!window.pdfMake.vfs) {
                return;
            }

            var stack = [];
            $.each($scope.group_question, function (index, value) {
                // Draw line
                stack.push({canvas: [{type: 'line', x1: 0, y1: 5, x2: 455, y2: 5, lineWidth: 1}]});
                // Group title
                stack.push(
                    {
                        text: (value.title == null) ? ' ' : $scope.cutInUTF8(value.title, 35, fontFlg),
                        fontSize: 14,
                        bold: true,
                        margin: [0, 10, 0, 5],
                        alignment: 'left',
                        font: fontDefault
                    }
                );
                // Draw line
                stack.push({canvas: [{type: 'line', x1: 0, y1: 5, x2: 455, y2: 5, lineWidth: 1}]});

                // For listing question
                $.each(value.question_list, function (idx, val) {
                    stack.push(
                        {
                            text: (val.question_content == null) ? ' ' : $scope.cutInUTF8(val.question_content, 40, fontFlg),
                            fontSize: 12,
                            margin: [30, 20, 0, 10],
                            color: '#ff0000',
                            alignment: 'left',
                            font: fontDefault
                        }
                    );

                    // For listing answer
                    $.each(val.answer_list, function (i, v) {
                        if (val.question_type == '1') {
                            // Munti choice
                            stack.push(
                                {
                                    columns: [
                                        {
                                            // you can also fit the image inside a rectangle
                                            image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAALUAAAC5CAMAAABZT47gAAAAeFBMVEX///8AAADNzc2UlJRFRUVYWFiPj4/T09P19fVOTk7x8fH5+fmysrLs7Ox7e3v4+PiJiYklJSVwcHC6uroWFhafn5+BgYHExMSnp6ehoaE2Njbb29saGhovLy9NTU1DQ0NdXV1mZmYNDQ1sbGzl5eUqKioSEhIhISGzrm8qAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4AQOCAM2JUv3MwAAA8RJREFUeNrtne1yqkAMhtkFYdEVBbUoaNVK2/u/w9P2fNS2ZHdRYeOZ9/0JOPNMDEk2zCRBAPHTtJZyrcO4D620lrJWtwVudLZfiv71GsWL8W1MrE9DAH+qysrJdcgzPRIe9FSUVzhGJrxpGU4vYpap8Kui6cxc+2Z+V9bN3tNC8FDYAVoLNtomjsxqJDhp7gS9EMyUO7yVK8FP0gZ9Ehy1MUOngqeMsWQvuCq+P0sbrb0XnEVYOxO8tbiXkPdVdUuJxx5aPP0456gX/tRi9J26EPcg/RW6dDtgVLtRL0qrndt//cVHJtbfbIt1Mu21c9Ekq6OV+nD+i9B2qJDD9FxmpS3RnZXbyvzkSgXDyXLEfvx8cm608zgYVvWjU9U6NvmzDIbX2tTk+fvQxhAhVeBD9Ys9Q+5o7/DVCp1FNibJD/otFtPOPft44MgQ2uQBHwlyQt1NPffLjdVIYv4n/In03PdGcdylCB9UmSFkR45V4fBSdDdK2RO+N4WkQWtLCvIpImkvZ1T/VLP47naiquzQofz2pgX1Oh5ar0c8vnESLrImQkjB5NPsc3vBH+TEdR46Et2zV6YpxpRosuDCPrdX6oI5dUzUdbypQyLCgRrUoAY1qEENalCDGtSgBjWoQQ1qUIMa1KAGNahBDWpQgxrUoAY1qEENalCDGtSgBjWoQQ1qUIMa1KAGNahBDWpQgxrUoAY1qEENalCDGtSgBjWoQf2/UO+ZUz+00p2C9jlnJRPqjKDOiWkoPFQQ80Oq1usPTKj3BHX7oMcjD2hixtqG8HcxYUFNzFhbUNMSE8aBTzTU/FceQ4i27XCKHJWpGEATFt2/OXz7ECLHNQH9KqL9gJprPPUOTW1O0IZ7qW9ocqLu+9aFhrrpOz8eCa78425FYfstRsgxwL+n6dPzbX0GbXrvSm32H58FK23KkbGw+pM7mbnH55TGhH7ET/E3Ns3u/lchmQZOVzWbOH32LtqM/ZaKhs03SWSkOStGD8LMPVwwKS3rj843zdTCoudwAPBZmdlm+W8dzsLfUnwWay2TPlTq9byoHBhKp0qWmb5X/fIeoJfKrV/CSy2F0SN76LZtPoq7a7d3Oxre0DsiXrJ+I/Nxx6YJC2hDW0nen6WdUrsfVZYGXvPMEPp0+dHYn8Lrjmx+5Hh4bTgtvCvce9JstsdtO/VkxjxW9W26Hixq/2/l/JJudOO1eN1evM9LbSJPzIfr2kfNqhoceaRv8KGiKR+GW1h6COXtVoCoZrGZp+lr/tTPgTDfpYd4XU59bz2CfugXlVNVBJHX5EYAAAAASUVORK5CYII=',
                                            width: 20,
                                            fit: [14, 14],
                                            margin: [40, 0, 20, 0]
                                        },
                                        {
                                            text: (v.title == null) ? ' ' : $scope.cutInUTF8(v.title, 35, fontFlg),
                                            margin: [45, 0, 0, 0]
                                        }

                                    ],
                                    font: fontDefault
                                }
                            );

                        } else if (val.question_type == '0') {
                            // Single choice
                            stack.push(
                                {
                                    columns: [
                                        {
                                            // you can also fit the image inside a rectangle
                                            image: 'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGsAAABqCAMAAACMPV+bAAAAclBMVEX///8AAADGxsYREREVFRXn5+e7u7v29vYvLy+tra0bGxve3t7z8/Pv7+9dXV3r6+vMzMwgICBISEhBQUGgoKBfX1+JiYlWVlbT09M7OzuUlJR0dHRFRUVqamp7e3vExMQqKiqFhYVPT0+bm5s0NDS0tLQpIwuKAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4AQOCAoewTzkgAAAA7dJREFUaN7NWtuCojAMBdxyESyVu9xGh+H/f3HVtVCgQIG0s3lDwJT05CRNomn/pXg+InkVnvWPnMMqJ8j3wBW5hlPddY7cK8dwARUhpw70BQlqB8FoyorbSV+R063IDiu6tHddUOz2ckST74T6Bgkdf68mq8X6RsGttQ966UnfLCe8A5RWPv0fO4jryHDRc+0Wco2ojgN7up5866eRsfnOOHE4UMucBJ/HhtwGyeZn+HoZkVkPQiQqh0//RBtUPYbvpmQFzReSDt9IhGliYL97IbTbbnEd2FGMSDJ2jX9qIrzFBYuTVGTTXNZ9g68NoLJMljXDdXO47PPJxoDhJew615RlzFeFZLtbEvb9ZTMiZq/qXWHJrZk9WwQIg8DE2smijB1jMb/Krd2UnYv4WdNTn3MkFDk9+OcYhPTEdEjVU1lPV3x8eD0u8qPhvDcjtpbvJ9ZRXQxAeOt2e7AfVvVU1kN/6jpWuoFcRPzs1llxcq/tsEM0ECEdpttxxoQ3h5416bYs9mdQGoDl517A96ALpcw/X3CpuUm3pRyE9RYSgx3cCvqvJvszTaTvRAMUQtMCm4eZAvYk1X1YxvnNhdXlTr8BUb9LoY+IlCBu/iQGEGhdZBKjai42IaTzpXqcOkUauDSjpMqgxwMCr4vQg4Ux5CeM4HV1idm/DfMqaNblMXD15ln/DpHPrKUe9hv1iF5lMnRl9ufvEesDgZzSUsD6bi6QpB4QzOY41cjdgIUSRfW6COV58ksiSkqvi5G3QQtliuvrQlI8mcQVVheSowvxdFlydFk8XbJqt7+tS5INvd/GhgrMq/RllRylkntVxhSVsVJlDqAyt1GZs6nMRZXm2CrODt+uujPR4zfOeirPsCrP5lqmsOagUSK5gu6Ywaul9DWiQn6NqMPmyZRe+5JS0ytnquISapWPuVolfA3WmK3BahaWVVuOF/wOpmbeYZCb44L2AvouUMO9j2X0OGL+ujN1vZs+RVXQk2LK9/J7bTA9xIdYDxGiN1qI9kYHPd/bDgYxbszAwtpij/Wy2aGFb4HG+aBHb27q0bOzFaXIFgxmD06FsCGN4eyB2G4PZyquu2YqYuF8PVE2K/JikNEMTNgszcA04YEZmOemTWZ70rnZnnQ82xNnB5immyILMJ1Z8t4zSziwp081OwjHxXtmseKdh7g23qoqbncHB98pt2gq98/OvdFs2sIzgebx45uyWcePKZdnOL8fx4w3BqXhVFxr2sCzqZ+A8Z65LTvau5aSZm4h5C89wTYq8aci6wAAAABJRU5ErkJggg==',
                                            width: 20,
                                            fit: [15, 15],
                                            margin: [40, 0, 20, 0]
                                        },
                                        {
                                            text: (v.title == null) ? ' ' : $scope.cutInUTF8(v.title, 35, fontFlg),
                                            margin: [45, 0, 0, 0]
                                        }
                                    ],
                                    font: fontDefault
                                }
                            );
                        } else {
                            // Input text
                            stack.push(
                                {
                                    columns: [
                                        {
                                            text: gettextCatalog.getString("Input text") + ': ____________________',
                                            margin: [40, 15, 10, 0]
                                        }

                                    ],
                                    font: fontDefault
                                }
                            );
                        }
                    });

                    if (val.has_other_answer == 1) {
                        stack.push(
                            {
                                columns: [
                                    {
                                        text: gettextCatalog.getString("Other") + ': ____________________',
                                        margin: [40, 15, 10, 0]
                                    }

                                ],
                                font: fontDefault
                            }
                        );
                    }
                });
            });
            var dd = {
                info: {
                    title: 'Export PDF',
                    author: 'CMS Team',
                    subject: 'Survey information'
                    //keywords: 'keywords for document',
                },
                pageSize: 'A4',
                pageMargins: 72,
                widths: ['*', 'auto', 100, '*'],
                header: function (currentPage, pageCount) {
                    if (typeof($scope.hospitalLogo) != 'undefined') {
                        return {
                            columns: [
                                {
                                    text: ($scope.hospitalObj.hosp_name == null) ? ' ' : $scope.hospitalObj.hosp_name,
                                    style: 'header'
                                },

                                {
                                    image: $scope.hospitalLogo,
                                    //margin: [65-(pageCount)*5, 5, 5, 5],
                                    margin: [0, 20, 20, 0],
                                    fit: [120, 120],
                                    alignment: 'right'
                                }
                            ],
                            font: fontDefault
                        };
                    } else {
                        return {
                            columns: [
                                {
                                    text: ($scope.hospitalObj.hosp_name == null) ? ' ' : $scope.hospitalObj.hosp_name,
                                    style: 'header'
                                }
                            ],
                            font: fontDefault
                        };
                    }
                },
                footer: function (currentPage, pageCount) {
                    return {
                        stack: [
                            {text: (currentPage == pageCount) ? gettextCatalog.getString('Thank you for your cooperation.'):'' , alignment: 'right', fontSize: 10, margin: [0, 0, 30, 0]},
                            {text: ($scope.hospitalObj.hosp_name == null) ? ' ' : $scope.hospitalObj.hosp_name, alignment: 'right', fontSize: 10, color: '#0000ff', margin: [0, 0, 30, 0]},
                            {text: ($scope.hospitalObj.address == null) ? ' ' : $scope.hospitalObj.address, fontSize: 10, alignment: 'right', margin: [0, 0, 30, 0]}
                        ],
                        font: fontDefault
                    };
                },
                defaultStyle: {
                    font: fontDefault
                },
                content: [
                    {
                        text: ($scope.item.survey_title == null) ? ' ' : $scope.cutInUTF8($scope.item.survey_title, 20, fontFlg),
                        widths: [300, 300],
                        //text: gettextCatalog.getString('Medical survey'),
                        fontSize: 24,
                        margin: [0, 50, 0, 20],
                        alignment: 'center',
                        font: fontDefault
                    },

                    {
                        table: {
                            widths: [150, 150],
                            headerRows: 2,
                            // keepWithHeaderRows: 1,
                            body: [
                                [{text: gettextCatalog.getString('Patient code'), font: fontDefault}, ($scope.item.patient_code == null) ? ' ' : $scope.item.patient_code],
                                [{text: gettextCatalog.getString('Patient name'), font: fontDefault}, ($scope.item.patient_name == null) ? ' ' : $scope.item.patient_name],
                                [{text: gettextCatalog.getString('Answered date'), font: fontDefault}, ($scope.item.answer_date == null) ? ' ' : $scope.item.answer_date]
                            ]
                        },
                        margin: [65, 0, 0, 0],
                        font: fontDefault
                    },

                    {
                        text: gettextCatalog.getString('Please help us make the following survey.'),
                        fontSize: 18,
                        margin: [0, 50, 0, 20],
                        alignment: 'left',
                        font: fontDefault
                    },
                    {
                        stack: stack,
                        font: fontDefault
                    }
                ],
                styles: {
                    header: {
                        fontSize: 15,
                        bold: true,
                        alignment: 'left',
                        margin: [40, 20, 0, 0]
                    },
                    subheader: {
                        fontSize: 14
                    },
                    superMargin: {
                        margin: [20, 0, 40, 0],
                        fontSize: 15
                    },
                    vnfont: {
                        font: "Times New Roman"
                    },
                    jpfont: {
                        font: "MS PGothic"
                    }
                }
            };

            pdfMake.fonts = {
                Roboto: {
                    normal: 'Roboto-Regular.ttf',
                    bold: 'Roboto-Medium.ttf',
                    italics: 'Roboto-Italic.ttf',
                    bolditalics: 'Roboto-Italic.ttf'
                },
                /*ipam: {
                 normal: 'ipam.ttf',
                 bold: 'ipam.ttf',
                 italics: 'ipam.ttf',
                 bolditalics: 'ipam.ttf'
                 }*/
                "Times New Roman": {
                    normal: 'times.ttf',
                    bold: 'times.ttf',
                    italics: 'times.ttf',
                    bolditalics: 'times.ttf'
                },
                "MS PGothic": {
                    normal: 'mspgothic.ttf',
                    bold: 'mspgothic.ttf',
                    italics: 'mspgothic.ttf',
                    bolditalics: 'mspgothic.ttf'
                }
            };
            pdfMake.createPdf(dd).download($scope.hospitalObj.hosp_code + '_survey.pdf');
            $('#export_survey_to_pdf').show();
            $('#loading_icon').hide();
        }

        /**
         * Redirect to screen CMS007.SurveySetting
         * */
        $scope.redirectToScreenSurveySetting = function (department) {
            $location.path('/survey/setting');
            $rootScope.department_code_redirect = department.department_code;
        };

    }
})
();
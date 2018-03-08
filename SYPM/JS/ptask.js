$(function(){ 
				$('#ptasktable').datagrid({
												onClickRow: function(rowIndex,rowData)
													{
													alert("µ¥»÷");
													},
												onDblClickRow: function(rowIndex,rowData)
													{
													alert("Ë«»÷");
													}
												});
			});
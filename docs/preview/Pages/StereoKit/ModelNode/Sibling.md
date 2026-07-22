---
layout: default
title: ModelNode.Sibling
description: The next ModelNode in the hierarchy, at the same level as this one. To the "right" on a hierarchy tree. Null if there are no more ModelNodes in the tree there.
---
# [ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html).Sibling

<div class='signature' markdown='1'>
[ModelNode]({{site.url}}/preview/Pages/StereoKit/ModelNode.html) Sibling{ get }
</div>

## Description
The next ModelNode in the hierarchy, at the same level as
this one. To the "right" on a hierarchy tree. Null if there are no
more ModelNodes in the tree there.


## Examples

### Non-recursive depth first node traversal
If you need to walk through a Model's node hierarchy, this is a method
of doing this without recursion! You essentially do this by walking the
tree down (Child) and to the right (Sibling), and if neither is present,
then walking back up (Parent) until it can keep going right (Sibling)
and then down (Child) again.
```csharp
static void DepthFirstTraversal(Model model)
{
	ModelNode node  = model.RootNode;
	int       depth = 0;
	while (node != null)
	{
		string tabs = new string(' ', depth*2);
		Log.Info(tabs + node.Name);

		if      (node.Child   != null) { node = node.Child; depth++; }
		else if (node.Sibling != null)   node = node.Sibling;
		else {
			while (node != null)
			{
				if (node.Sibling != null) {
					node = node.Sibling;
					break;
				}
				depth--;
				node = node.Parent;
			}
		}
	}
}
```
### Recursive depth first node traversal
Recursive depth first traversal is a little simpler to implement as
long as you don't mind some recursion :)
This would be called like: `RecursiveTraversal(model.RootNode);`
```csharp
static void RecursiveTraversal(ModelNode node, int depth = 0)
{
	string tabs = new string(' ', depth*2);
	while (node != null)
	{
		Log.Info(tabs + node.Name);
		RecursiveTraversal(node.Child, depth + 1);
		node = node.Sibling;
	}
}
```


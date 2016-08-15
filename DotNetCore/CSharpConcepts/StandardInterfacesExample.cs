using System;
using System.Collections;
using System.Collections.Generic;
namespace CSharpConcepts
{
	public class StandardInterfacesExample
	{
		public void Run()
		{
			Console.WriteLine("Standard Interface implementations");
			IEnumerableImplementation();
		}

		public void IEnumerableImplementation()
		{
			TreeNode president = new TreeNode("President");
			TreeNode sales = president.AddChild("VP Sales");
			sales.AddChild("Domestic Sales");
			sales.AddChild("International Sales");
			// Other tree-building code omitted.
			//...
			// Display the tree.
			string text = "";
			//IEnumerator<TreeNode> enumerator = president.GetEnumerator();
			//while (enumerator.MoveNext())
			//text += new string(' ', 4 * enumerator.Current.Depth) + enumerator.Current.Text + Environment.NewLine;
			foreach(TreeNode node in president)
			{
				text += new string(' ', 4 * node.Depth) + node.Text + Environment.NewLine;
			}
			text = text.Substring(0, text.Length - Environment.NewLine.Length);
			Console.WriteLine(text);
		}

		public class TreeNode:IEnumerable<TreeNode>
		{
			public int Depth = 0;
			public string Text = "";
			List<TreeNode> Children = new List<TreeNode>();
			
			public TreeNode(string text)
			{
				this.Text = text;
			}
			public TreeNode AddChild(string text)
			{
				TreeNode child = new TreeNode(text);
				child.Depth = this.Depth +1;
				Children.Add(child);
				return child;
			}

			public List<TreeNode> PreOrder()
			{
				List<TreeNode> nodes = new List<TreeNode>();
				TraversePreOrder(nodes);
				return nodes;
			}

			public void TraversePreOrder(List<TreeNode> nodes)
			{
				nodes.Add(this);
				foreach(TreeNode child in Children)
					child.TraversePreOrder(nodes);
			}

			public IEnumerator<TreeNode> GetEnumerator()
			{
				List<TreeNode> nodes = PreOrder();
				foreach(TreeNode node in nodes)
					yield return node;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				List<TreeNode> nodes = PreOrder();
				foreach(TreeNode node in nodes)
					yield return node;
			}
		}
	}
}

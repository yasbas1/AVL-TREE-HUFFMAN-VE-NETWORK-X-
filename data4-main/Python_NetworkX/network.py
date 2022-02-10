import networkx as nx
from matplotlib import pyplot as plt

DGraph = nx.DiGraph()

vertex_list = [0,1,2,3,4]
edges_list = [(0,4,2),(0,2,3),(0,1,5),
(1,2,2),(1,3,6),
(2,1,1),(2,3,2),
(4,3,4),(4,2,10),(4,1,6),
]

DGraph.add_nodes_from(vertex_list)
DGraph.add_weighted_edges_from(edges_list)

# resimdeki şekle benzemesi için x,y değerleri ekledim , aksi takdirde her seferinde rastgele oluşturuyor.
DGraph._node[0]['pos'] = (0,8)
DGraph._node[1]['pos'] = (4,2)
DGraph._node[2]['pos'] = (2,-4)
DGraph._node[3]['pos'] = (-2,-4)
DGraph._node[4]['pos'] = (-4,2)

node_pos=nx.get_node_attributes(DGraph,'pos')
arc_weight=nx.get_edge_attributes(DGraph,'weight')

nx.draw_networkx_nodes(DGraph ,node_pos)
nx.draw_networkx_labels(DGraph , node_pos)
nx.draw_networkx_edges(DGraph, node_pos,connectionstyle='arc3,rad=0.1')
nx.draw_networkx_edge_labels(DGraph, node_pos, edge_labels=arc_weight , label_pos=0.33)

# Dijkstra Path
for i in range(5):
    try:
        d_path = nx.dijkstra_path(DGraph , 4 ,i)
        print("4. köşeden " , i ,". köşeye" ,"En kısa dijkstra yolu : " , *d_path)
    except nx.NetworkXNoPath:
        print("4. köşeden ", i , ". köşeye yol yok")
    

plt.axis('off')
plt.show()

print("------------------")
print("3. köşe silindi")
print(" ")

#3. köşe silinmiş hali
DGraph.remove_node(3)
DGraph._node[0]['pos'] = (0,8)
DGraph._node[1]['pos'] = (4,2)
DGraph._node[2]['pos'] = (2,-4)
DGraph._node[4]['pos'] = (-4,2)

node_pos=nx.get_node_attributes(DGraph,'pos')
arc_weight=nx.get_edge_attributes(DGraph,'weight')

nx.draw_networkx_nodes(DGraph , pos=node_pos)
nx.draw_networkx_labels(DGraph , node_pos)
nx.draw_networkx_edges(DGraph, node_pos, connectionstyle='arc3,rad=0.1')
nx.draw_networkx_edge_labels(DGraph, node_pos, edge_labels=arc_weight , label_pos=0.33)

for i in range(5):
    try:
        if(i == 3):
            continue
        d_path = nx.dijkstra_path(DGraph , 4 ,i)
        print("4. köşeden " , i ,". köşeye" ,"En kısa dijkstra yolu : " , *d_path)
    except nx.NetworkXNoPath:
        print("4. köşeden ", i , ". köşeye yol yok")

plt.axis('off')
plt.show()
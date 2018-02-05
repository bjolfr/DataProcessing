## Meta Constructor
This is a light-weight approach in database modeling gives an opportunity to describe abstract objects, its properties and features in business-process modeling, a database, an application, an ETL configuration, etc.

If you software developer it gives you an opportunity to focus on algorithms and pass the turning, mapping, translating, etc. to responsible staff.
### Objects and properties
Objects can be classified and organized, base on that classification, in hierarchy. At least they can be collected to a list so that list, as an object itself, contains the other objects.  And the object can be complex and consists from a set of another objects. And of’ course every object can have its own variable set of properties independent of the other objects. On the other hands since we’re talking about a set of independent objects with their properties from one the point it would be nice to arrange them in one hierarchy list for further operations.
So we’ve created such a list.

- Constants
- Catalogs
  - Product Types
    - Tax base
    - Tax exception
    - Hash func
    - Node ...
- Documents
- Sequencies

In that example it describes the structure of catalogs (reference data), which present by itself tables in accounting database. Catalog Product Types has three attributes for translation and consists from four properties.

| Property | Values |
|------------- | ------------- |
| en-EN  | Product Types  |
| ru-RU  | Тип продукта |
| de_DE  | Produkttypen |

Each property describes a real entity in a database area, for instance Tax Exception is column in table ProductTypes refers to linked table describes tax exception rules, and Node refers to a row in a table responsible for blockchain function. Each property has its own set of attributes describe it in detail. 

| Property | Values |
|------------- | ------------- |
| en-EN  | Node  |
| de_DE  | Knoten |
| Type  | Ref |
| SQLParam  | @Node |

That approach gives the opportunity to configure a lot of desired processes. If you want to create map to the field in the table you can add attribute which consists a parameter of a stored procedure and attribute consists correspondent name of external field. Or you can to call some procedure of function if you algorithm demands additional action you can add appropriate attribute to a related object/property.

For instance, that application automatically loads names of the objects in the tree, columns and dialogs based on current culture on client computer and corresponding attribute in database. 

### Catalogs
Catalogs (references data) are very common in any database modeling and represent a set of permissible values to be (re)used by other data fields. A real-word database can have a lot of references data, organized in tables or by identification fields, so after several hundred such tables, your code can be not very readable. Besides that you possibly want to add specific presentation for different catalogs, not only plain list but hierarchy or both. In that case it’ll be helpful to organize them in some readable manner.

That approach gives an opportunity to address and manipulate with references, items, and their properties with dot notation. For instance, `public Element Catalogs.PropertyTypes.FindByCode()`. If you think about people who will read, maintain and use your code after, you can find that approach very useful. IntelliSence can describe in details every catalog, you can use Factory pattern for create and manipulate elements of the catalogs, and can have special functions for a catalog.

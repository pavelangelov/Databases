<?xml version="1.0" encoding="utf-8"?>
<xs:stylesheet version="1.0" xmlns:xs="http://www.w3.org/1999/XSL/Transform">
  <xs:output method="html"/>

  <xs:template match="/">
    <html xmlns="http://www.w3.org/1999/xhtml">
      <head>
        <style>
          table {
            border-collapse: collapse;
            background-color: pink;
          }

          td, th {
            padding: 5px;
            border: 1px solid black;
          }

          .left {
            color: blue;
          }

          .right {
            color: green;
          }

          hr {
            border-color: black;
          }
        </style>
      </head>
      <body>
        <h1>My Students XML</h1>
        <table>
          <tr>
            <th>Name</th>
            <th>Sex</th>
            <th>Birth-day</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty-Number</th>
            <th>Exams</th>
          </tr>
          <xs:for-each select="students/student">
            <tr>
              <td>
                <xs:value-of select="name"/>
              </td>
              <td>
                <xs:value-of select="sex"/>
              </td>
              <td>
                <xs:value-of select="birthDate"/>
              </td>
              <td>
                <xs:value-of select="phone"/>
              </td>
              <td>
                <xs:value-of select="email"/>
              </td>
              <td>
                <xs:value-of select="course"/>
              </td>
              <td>
                <xs:value-of select="specialty"/>
              </td>
              <td>
                <xs:value-of select="facultyNumber"/>
              </td>
              <td>
                <xs:for-each select="exams/exam">
                  <div>
                    <span class="left">Course Name:</span>
                    <span class="right"><xs:value-of select="name"/>
                    </span>
                  </div>
                  <div>
                    <span class="left">Tutor Name:</span>
                    <span class="right"><xs:value-of select="tutor"/></span>
                  </div>
                  <div>
                   <span class="left"> Score:</span>
                   <span class="right"> <xs:value-of select="score"/></span>
                  </div>
                  <hr/>
                </xs:for-each>
              </td>
            </tr>
          </xs:for-each>
        </table>
      </body>
    </html>
  </xs:template>
</xs:stylesheet>
<?xml version="1.0" encoding="windows-1251"?>
<!-- Edited by XMLSpyÂ® -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  <body>
  <h2> Albums Catalogue </h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th style="text-align:left">Album Name</th>
        <th style="text-align:left">Artist</th>
        <th style="text-align:left">Year</th>
        <th style="text-align:left">Producer</th>
        <th style="text-align:left">Price USD</th>
        <th style="text-align:left">Songs</th>
      </tr>
      <xsl:for-each select="catalogue/album">
      <tr>
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="artist"/></td>
        <td><xsl:value-of select="year"/></td>
        <td><xsl:value-of select="producer"/></td>
        <td><xsl:value-of select="price"/></td>
		<td>
		<table border="1">
			<tr bgcolor="#9acd32">
				<th style="text-align:left">Title</th>
				<th style="text-align:left">Duration</th>
			</tr>
			<xsl:for-each select="songs/song">
			<tr>
				<td><xsl:value-of select="title"/></td>
				<td><xsl:value-of select="duration"/></td>
			</tr>
			</xsl:for-each>
		</table>
        </td>
      </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>

<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <!-- Find the root node called Menus 
       and call MenuListing for its children -->
  <xsl:template match="/NewDataSet">
    <MenuItems>
      <xsl:call-template name="MenuListing" />
    </MenuItems>
  </xsl:template>

  <!-- Allow for recusive child node processing -->
  <xsl:template name="MenuListing">
    <xsl:apply-templates select="Table" />
  </xsl:template>

  <xsl:template match="Table">
    <MenuItem>
      <!-- Convert Menu child elements to MenuItem attributes -->
      <xsl:attribute name="Text">
        <xsl:value-of select="vch_desc_item"/>
      </xsl:attribute>

      <xsl:attribute name="NavigateUrl">
        <xsl:value-of select="vch_value"/>
      </xsl:attribute>

      <!-- Call MenuListing if there are child Menu nodes -->
      <xsl:if test="count(Table) > 0">
        <xsl:call-template name="MenuListing" />
      </xsl:if>
    </MenuItem>
  </xsl:template>
</xsl:stylesheet>

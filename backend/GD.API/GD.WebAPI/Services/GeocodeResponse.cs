namespace GD.WebAPI.Services
{
    // REMARQUE : Le code généré peut nécessiter au moins .NET Framework 4.5 ou .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class GeocodeResponse
    {

        private string statusField;

        private GeocodeResponseResult resultField;

        /// <remarks/>
        public string status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        public GeocodeResponseResult result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResult
    {

        private string typeField;

        private string formatted_addressField;

        private GeocodeResponseResultAddress_component[] address_componentField;

        private GeocodeResponseResultGeometry geometryField;

        private string place_idField;

        private GeocodeResponseResultPlus_code plus_codeField;

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string formatted_address
        {
            get
            {
                return this.formatted_addressField;
            }
            set
            {
                this.formatted_addressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("address_component")]
        public GeocodeResponseResultAddress_component[] address_component
        {
            get
            {
                return this.address_componentField;
            }
            set
            {
                this.address_componentField = value;
            }
        }

        /// <remarks/>
        public GeocodeResponseResultGeometry geometry
        {
            get
            {
                return this.geometryField;
            }
            set
            {
                this.geometryField = value;
            }
        }

        /// <remarks/>
        public string place_id
        {
            get
            {
                return this.place_idField;
            }
            set
            {
                this.place_idField = value;
            }
        }

        /// <remarks/>
        public GeocodeResponseResultPlus_code plus_code
        {
            get
            {
                return this.plus_codeField;
            }
            set
            {
                this.plus_codeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultAddress_component
    {

        private string long_nameField;

        private string short_nameField;

        private string[] typeField;

        /// <remarks/>
        public string long_name
        {
            get
            {
                return this.long_nameField;
            }
            set
            {
                this.long_nameField = value;
            }
        }

        /// <remarks/>
        public string short_name
        {
            get
            {
                return this.short_nameField;
            }
            set
            {
                this.short_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("type")]
        public string[] type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultGeometry
    {

        private GeocodeResponseResultGeometryLocation locationField;

        private string location_typeField;

        private GeocodeResponseResultGeometryViewport viewportField;

        /// <remarks/>
        public GeocodeResponseResultGeometryLocation location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        public string location_type
        {
            get
            {
                return this.location_typeField;
            }
            set
            {
                this.location_typeField = value;
            }
        }

        /// <remarks/>
        public GeocodeResponseResultGeometryViewport viewport
        {
            get
            {
                return this.viewportField;
            }
            set
            {
                this.viewportField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultGeometryLocation
    {

        private decimal latField;

        private decimal lngField;

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }

        /// <remarks/>
        public decimal lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultGeometryViewport
    {

        private GeocodeResponseResultGeometryViewportSouthwest southwestField;

        private GeocodeResponseResultGeometryViewportNortheast northeastField;

        /// <remarks/>
        public GeocodeResponseResultGeometryViewportSouthwest southwest
        {
            get
            {
                return this.southwestField;
            }
            set
            {
                this.southwestField = value;
            }
        }

        /// <remarks/>
        public GeocodeResponseResultGeometryViewportNortheast northeast
        {
            get
            {
                return this.northeastField;
            }
            set
            {
                this.northeastField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultGeometryViewportSouthwest
    {

        private decimal latField;

        private decimal lngField;

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }

        /// <remarks/>
        public decimal lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultGeometryViewportNortheast
    {

        private decimal latField;

        private decimal lngField;

        /// <remarks/>
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }

        /// <remarks/>
        public decimal lng
        {
            get
            {
                return this.lngField;
            }
            set
            {
                this.lngField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GeocodeResponseResultPlus_code
    {

        private string global_codeField;

        private string compound_codeField;

        /// <remarks/>
        public string global_code
        {
            get
            {
                return this.global_codeField;
            }
            set
            {
                this.global_codeField = value;
            }
        }

        /// <remarks/>
        public string compound_code
        {
            get
            {
                return this.compound_codeField;
            }
            set
            {
                this.compound_codeField = value;
            }
        }
    }
}

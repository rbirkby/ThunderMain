using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


    /// <summary>
    /// Useful debugging class. Simply wrap any XmlReader in this Decorator and
    /// obtain useful AOP-like method entry information
    /// </summary>
    public class XmlReaderDecorator : XmlReader {
        XmlReader _internal;

        /// <summary></summary>
        public XmlReaderDecorator(XmlReader internalReader) {
            _internal = internalReader;
        }
        /// <summary></summary>
        public override string ReadOuterXml() {
            return _internal.ReadOuterXml();
        }
        /// <summary></summary>
        public override bool ReadAttributeValue() {
            return _internal.ReadAttributeValue();
        }
        /// <summary></summary>
        public override bool IsEmptyElement {
            get {
                return _internal.IsEmptyElement;
            }
        }
        /// <summary></summary>
        public override void ResolveEntity() {
            _internal.ResolveEntity();
        }
        /// <summary></summary>
        public override string LookupNamespace(string prefix) {
            return _internal.LookupNamespace(prefix);
        }
        /// <summary></summary>
        public override XmlNameTable NameTable {
            get {
                return _internal.NameTable;
            }
        }


        /// <summary></summary>
        public override string ReadInnerXml() {
            return _internal.ReadInnerXml();
        }
        /// <summary></summary>
        public override string ReadString() {
            return _internal.ReadString();
        }

        /// <summary></summary>
        public override ReadState ReadState {
            get {
                return _internal.ReadState;
            }
        }
        /// <summary></summary>
        public override void Close() {
            _internal.Close();
        }
        /// <summary></summary>
        public override bool EOF {
            get {
                return _internal.EOF;
            }
        }
        /// <summary></summary>
        public override bool Read() {
            return _internal.Read();
        }
        /// <summary></summary>
        public override bool MoveToElement() {
            return _internal.MoveToElement();
        }
        /// <summary></summary>
        public override bool MoveToNextAttribute() {
            bool bResult = _internal.MoveToNextAttribute();
            return bResult;
        }
        /// <summary></summary>
        public override bool MoveToFirstAttribute() {
            return _internal.MoveToFirstAttribute();
        }
        /// <summary></summary>
        public override void MoveToAttribute(int i) {
            _internal.MoveToAttribute(i);
        }
        /// <summary></summary>
        public override bool MoveToAttribute(string localName, string namespaceURI) {
            return _internal.MoveToAttribute(localName, namespaceURI);
        }
        /// <summary></summary>
        public override bool MoveToAttribute(string name) {
            return _internal.MoveToAttribute(name);
        }
        /// <summary></summary>
        public override string this[string name, string namespaceURI] {
            get {
                return _internal[name, namespaceURI];
            }
        }
        /// <summary></summary>
        public override string this[string name] {
            get {
                return _internal[name];
            }
        }
        /// <summary></summary>
        public override string this[int i] {
            get {
                return _internal[i];
            }
        }
        /// <summary></summary>
        public override string GetAttribute(int i) {
            return _internal.GetAttribute(i);
        }
        /// <summary></summary>
        public override string GetAttribute(string localName, string namespaceURI) {
            return _internal.GetAttribute(localName, namespaceURI);
        }
        /// <summary></summary>
        public override string GetAttribute(string name) {
            return _internal.GetAttribute(name);
        }
        /// <summary></summary>
        public override int AttributeCount {
            get {
                return _internal.AttributeCount;
            }
        }
        /// <summary></summary>
        public override string XmlLang {
            get {
                return _internal.XmlLang;
            }
        }
        /// <summary></summary>
        public override XmlSpace XmlSpace {
            get {
                return _internal.XmlSpace;
            }
        }
        /// <summary></summary>
        public override char QuoteChar {
            get {
                return _internal.QuoteChar;
            }
        }
        /// <summary></summary>
        public override bool IsDefault {
            get {
                return _internal.IsDefault;
            }
        }

        /// <summary></summary>
        public override string BaseURI {
            get {
                return _internal.BaseURI;
            }
        }
        /// <summary></summary>
        public override int Depth {
            get {
                return _internal.Depth;
            }
        }
        /// <summary></summary>
        public override string Value {
            get {
                return _internal.Value;
            }
        }
        /// <summary></summary>
        public override bool HasValue {
            get {
                return _internal.HasValue;
            }
        }
        /// <summary></summary>
        public override string Prefix {
            get {
                return _internal.Prefix;
            }
        }
        /// <summary></summary>
        public override string NamespaceURI {
            get {
                return _internal.NamespaceURI;
            }
        }
        /// <summary></summary>
        public override string LocalName {
            get {
                try {
                    return XmlConvert.VerifyName(_internal.LocalName);
                } catch (XmlException) {
                    return "INVALIDNAME";
                }
            }
        }
        /// <summary></summary>
        public override string Name {
            get {
                try {
                    return XmlConvert.VerifyName(_internal.Name);
                } catch (XmlException) {
                    return "INVALIDNAME";
                }
            }
        }
        /// <summary></summary>
        public override XmlNodeType NodeType {
            get {
                return _internal.NodeType;
            }
        }
    }


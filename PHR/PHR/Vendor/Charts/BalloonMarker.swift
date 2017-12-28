//
//  BalloonMarker.swift
//  ChartsDemo
//
//  Created by Daniel Cohen Gindi on 19/3/15.
//
//  Copyright 2015 Daniel Cohen Gindi & Philipp Jahoda
//  A port of MPAndroidChart for iOS
//  Licensed under Apache License 2.0
//
//  https://github.com/danielgindi/ios-charts
//

import Foundation;
import Charts;

public class BalloonMarker: ChartMarker
{
    public var color: UIColor?
    public var fillColor: UIColor?
    public var arrowSize = CGSize(width: 6, height: 3)
    public var font: UIFont?
    public var insets = UIEdgeInsets()
    public var minimumSize = CGSize()
    public var cornerRadius = CGFloat(3.0) // to draw corner radius
    private var labelns: NSString?
    private var _labelSize: CGSize = CGSize()
    private var _size: CGSize = CGSize()
    private var _paragraphStyle: NSMutableParagraphStyle?
    private var _drawAttributes = [String : AnyObject]()
    public var isShowDigit = 0;
    
    public init(color: UIColor,fillColor: UIColor, font: UIFont, insets: UIEdgeInsets)
    {
        super.init()
        
        self.color = color
        self.fillColor = fillColor;
        self.font = font
        self.insets = insets
        
        _paragraphStyle = NSParagraphStyle.defaultParagraphStyle().mutableCopy() as? NSMutableParagraphStyle
        _paragraphStyle?.alignment = .Center
    }
    
    public init(color: UIColor, font: UIFont, insets: UIEdgeInsets)
    {
        super.init()
        
        self.color = color
        self.font = font
        self.insets = insets
        
        _paragraphStyle = NSParagraphStyle.defaultParagraphStyle().mutableCopy() as? NSMutableParagraphStyle
        _paragraphStyle?.alignment = .Center
    }
    
    public override var size: CGSize { return _size; }
    
    public override func draw(context context: CGContext, point: CGPoint)
    {
        if (labelns == nil)
        {
            return
        }
        
        let offset = self.offsetForDrawingAtPos(point)
        var rect = CGRect(origin: CGPoint(x: point.x + offset.x,y: point.y + offset.y),size: _size)
        rect.origin.x -= _size.width / 2.0
        rect.origin.y -= _size.height * 1.5
        
        CGContextSaveGState(context)
        
        CGContextSetStrokeColorWithColor(context, color?.CGColor)
        CGContextSetFillColorWithColor(context, fillColor?.CGColor);

        CGContextBeginPath(context)
        CGContextMoveToPoint(context,
            rect.origin.x + cornerRadius,
            rect.origin.y)
        CGContextAddLineToPoint(context,
            rect.origin.x + rect.size.width - cornerRadius,
            rect.origin.y)
        CGContextAddArc(context,
                        rect.origin.x + rect.size.width - cornerRadius,
                        rect.origin.y + cornerRadius,
                        cornerRadius, CGFloat(-M_PI_2), CGFloat(0), 0)
        CGContextAddLineToPoint(context,
            rect.origin.x + rect.size.width,
            rect.origin.y + rect.size.height - arrowSize.height - cornerRadius)
        CGContextAddArc(context,
                        rect.origin.x + rect.size.width - cornerRadius,
                        rect.origin.y + rect.size.height - arrowSize.height - cornerRadius,
                        cornerRadius, CGFloat(0), CGFloat(M_PI_2), 0)
        CGContextAddLineToPoint(context,
            rect.origin.x + (rect.size.width + arrowSize.width) / 2.0,
            rect.origin.y + rect.size.height - arrowSize.height)
        CGContextAddLineToPoint(context,
            rect.origin.x + rect.size.width / 2.0,
            rect.origin.y + rect.size.height)
        CGContextAddLineToPoint(context,
            rect.origin.x + (rect.size.width - arrowSize.width) / 2.0,
            rect.origin.y + rect.size.height - arrowSize.height)
        CGContextAddLineToPoint(context,
                                rect.origin.x + cornerRadius,
                                rect.origin.y + rect.size.height - arrowSize.height)
        CGContextAddArc(context,
                        rect.origin.x + cornerRadius,
                        rect.origin.y + rect.size.height - (arrowSize.height + cornerRadius),
                        cornerRadius, CGFloat(M_PI_2), CGFloat(M_PI), 0)
        CGContextAddLineToPoint(context,
            rect.origin.x,
            rect.origin.y + cornerRadius)
        CGContextAddArc(context,
                        rect.origin.x + cornerRadius,
                        rect.origin.y + cornerRadius,
                        cornerRadius, CGFloat(M_PI), CGFloat(-M_PI_2), 0)
        
        CGContextDrawPath(context, CGPathDrawingMode.FillStroke);
        
        rect.origin.y += self.insets.top
        rect.size.height -= self.insets.top + self.insets.bottom
        
        
        UIGraphicsPushContext(context)
        
        
        
        labelns?.drawInRect(rect, withAttributes: _drawAttributes)
        
        UIGraphicsPopContext()
       
        CGContextRestoreGState(context)
    }
    
    public override func refreshContent(entry entry: ChartDataEntry, highlight: ChartHighlight)
    {
        //TungNT
        var label:NSString
        if (isShowDigit == 2) {
            label = String(format:"%0.2f", entry.value)
        } else if (isShowDigit == 1){
            label = String(format:"%0.1f", entry.value)
        } else {
            label = String(format:"%0.0f", entry.value)
        }
        labelns = label as NSString
        _drawAttributes.removeAll()
        _drawAttributes[NSFontAttributeName] = self.font
        _drawAttributes[NSParagraphStyleAttributeName] = _paragraphStyle
        _drawAttributes[NSForegroundColorAttributeName] = self.color
        _labelSize = labelns?.sizeWithAttributes(_drawAttributes) ?? CGSizeZero
        _size.width = _labelSize.width + self.insets.left + self.insets.right
        _size.height = _labelSize.height + self.insets.top + self.insets.bottom
        _size.width = max(minimumSize.width, _size.width)
        _size.height = max(minimumSize.height, _size.height)
    }
}
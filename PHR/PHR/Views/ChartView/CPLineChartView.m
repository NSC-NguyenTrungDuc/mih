//
//  CPLineChartView.m
//  PHR
//
//  Created by NextopHN on 4/25/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "CPLineChartView.h"

static NSString* BASIC_PLOT = @"BASIC_PLOT";
static NSString* SMA_PLOT = @"SMA_PLOT";
static double majorTickLength = 5.0;
static double minorTickLength = 2.0;
static int PERIOD = 2;
@interface LineChartView (){
    
}
@end

@implementation CPLineChartView

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (void)initPlot {
    self.arrayPlotIdentifier = [[NSMutableArray alloc]init];
    self.isSMAShowed = NO;
    
    [self configureHost];
    [self configureGraph];
    [self configurePlots];
    [self configureAxes];
}

#pragma mark - Configuration function
- (void)configureHost{
    self.chartHostingView = [(CPTGraphHostingView *) [CPTGraphHostingView alloc] initForAutoLayout];
    self.chartHostingView.allowPinchScaling = YES;
    [self addSubview:self.chartHostingView];
    
    [self.chartHostingView autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.chartHostingView autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.chartHostingView autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.chartHostingView autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
}

- (void)configureGraph{
    
    self.graph = [[CPTXYGraph alloc] initWithFrame:self.chartHostingView.bounds];
    [self.graph setIdentifier:@"GLOBAL"];
    [self.chartHostingView setHostedGraph:self.graph];
    
    [[self.graph plotAreaFrame] setBorderLineStyle:nil];
    
    // BASIC
    //self.graph.plotAreaFrame.fill          = [CPTFill fillWithColor:[CPTColor lightGrayColor]];
    self.graph.plotAreaFrame.paddingTop    = self.titleSize;
    self.graph.plotAreaFrame.paddingBottom = self.titleSize;
    self.graph.plotAreaFrame.paddingLeft   = self.titleSize;
    self.graph.plotAreaFrame.paddingRight  = self.titleSize;
    self.graph.plotAreaFrame.cornerRadius  = 10.0;
    self.graph.plotAreaFrame.masksToBorder = NO;
    
    self.graph.borderLineStyle = nil;
    
    self.graph.plotAreaFrame.plotArea.fill = [CPTFill fillWithColor:[CPTColor clearColor]];
    
    // Setup plot space
    CPTXYPlotSpace *plotSpace = (CPTXYPlotSpace *)self.graph.defaultPlotSpace;
    [plotSpace setXRange:[CPTPlotRange plotRangeWithLocationDecimal:CPTDecimalFromInt(0) lengthDecimal:CPTDecimalFromInt(30)]];
    [plotSpace setYRange:[CPTPlotRange plotRangeWithLocationDecimal:CPTDecimalFromInt(0) lengthDecimal:CPTDecimalFromInt(20)]];
}

- (void)configurePlots{
    self.basicScatterPlot = [[CPTScatterPlot alloc] initWithFrame:[self.graph bounds]];
    [self.basicScatterPlot setIdentifier:BASIC_PLOT];
    [self.basicScatterPlot setDelegate:self];
    [self.basicScatterPlot setDataSource:self];
    
    CPTMutableLineStyle *mainPlotLineStyle = [[self.basicScatterPlot dataLineStyle] mutableCopy];
    [mainPlotLineStyle setLineWidth:1.5];
    [mainPlotLineStyle setLineColor:[CPTColor whiteColor]];
    
    [self.basicScatterPlot setDataLineStyle:mainPlotLineStyle];
    
    CPTColor *areaColor = [CPTColor colorWithCGColor:[RGBACOLOR(255, 255, 255, 0.7) CGColor]];
    CPTGradient *areaGradient = [CPTGradient gradientWithBeginningColor:areaColor endingColor:[CPTColor colorWithCGColor:[RGBACOLOR(255, 255, 255, 0.05) CGColor]]];
    [areaGradient setAngle:-90.0f];
    CPTFill *areaGradientFill = [CPTFill fillWithGradient:areaGradient];
    [self.basicScatterPlot setAreaFill:areaGradientFill];
    [self.basicScatterPlot setAreaBaseValue:@(0)];
    
    // SMA
    self.SMAScatterPlot = [[CPTScatterPlot alloc] initWithFrame:[self.graph bounds]];
    [self.SMAScatterPlot setIdentifier:SMA_PLOT];
    [self.SMAScatterPlot setDelegate:self];
    [self.SMAScatterPlot setDataSource:self];
    
    CPTMutableLineStyle *lineStyle = [self.SMAScatterPlot.dataLineStyle mutableCopy];
    lineStyle.miterLimit        = 1.0;
    lineStyle.lineWidth         = 2.0;
    lineStyle.lineColor         = [CPTColor redColor];
    self.SMAScatterPlot.dataLineStyle = lineStyle;
    
    //    CPTMutableLineStyle *mainPlotLineStyleSMA = [[SMAScatterPlot dataLineStyle] mutableCopy];
    //    [mainPlotLineStyle setLineWidth:3.0f];
    //    [mainPlotLineStyle setLineColor:[CPTColor colorWithCGColor:[[UIColor whiteColor] CGColor]]];
    //
    //    [SMAScatterPlot setDataLineStyle:mainPlotLineStyleSMA];
    
    //    CPTColor *areaColorSMA = [CPTColor colorWithCGColor:[RGBACOLOR(220, 127, 127, 0.8) CGColor]];
    //    CPTGradient *areaGradientSMA = [CPTGradient gradientWithBeginningColor:areaColorSMA endingColor:[CPTColor colorWithCGColor:[RGBACOLOR(220, 127, 127, 0.1) CGColor]]];
    //    [areaGradientSMA setAngle:-90.0f];
    //CPTFill *areaGradientFillSMA = [CPTFill fillWithGradient:areaGradient];
    //[SMAScatterPlot setAreaFill:areaGradientFillSMA];
    //    [SMAScatterPlot setAreaBaseValue:@(0)];
    
    self.SMAScatterPlot.interpolation = CPTScatterPlotInterpolationCurved;
    [self.graph addPlot:self.basicScatterPlot];
    [self.arrayPlotIdentifier addObject:BASIC_PLOT];
    
    [self.graph addPlot:self.SMAScatterPlot];
    [self.arrayPlotIdentifier addObject:SMA_PLOT];
}

- (void)configureAxes{
    NSNumberFormatter *axisFormatter = [[NSNumberFormatter alloc] init];
    [axisFormatter setMinimumIntegerDigits:1];
    [axisFormatter setMaximumFractionDigits:0];
    
    CPTMutableTextStyle *textStyle = [CPTMutableTextStyle textStyle];
    [textStyle setFontSize:12.0f];
    
    CPTXYPlotSpace *plotSpace = (CPTXYPlotSpace *)self.graph.defaultPlotSpace;
    // Line styles
    CPTMutableLineStyle *axisLineStyle = [CPTMutableLineStyle lineStyle];
    axisLineStyle.lineWidth = 1.0;
    axisLineStyle.lineCap   = kCGLineCapRound;
    
    CPTMutableLineStyle *majorGridLineStyle = [CPTMutableLineStyle lineStyle];
    majorGridLineStyle.lineWidth = 0.75;
    majorGridLineStyle.lineColor = [CPTColor redColor];
    
    CPTMutableLineStyle *minorGridLineStyle = [CPTMutableLineStyle lineStyle];
    minorGridLineStyle.lineWidth = 0.25;
    minorGridLineStyle.lineColor = [CPTColor blueColor];
    
    // Text styles
    CPTMutableTextStyle *axisTitleTextStyle = [CPTMutableTextStyle textStyle];
    axisTitleTextStyle.fontName = @"Helvetica";
    axisTitleTextStyle.color = [CPTColor whiteColor];
    axisTitleTextStyle.fontSize = 9.0;
    
    // Axes
    // Label x axis with a fixed interval policy
    CPTXYAxisSet *axisSet = (CPTXYAxisSet *)self.graph.axisSet;
    CPTXYAxis *x          = axisSet.xAxis;
    
    axisLineStyle.lineColor = [CPTColor whiteColor];
    x.separateLayers              = NO;
    x.preferredNumberOfMajorTicks = 0;
    x.orthogonalPosition    = @1.0;
    //x.majorIntervalLength   = @12.0;
    x.minorTicksPerInterval = 0.0;
    x.tickDirection         = CPTSignNone;
    x.labelingPolicy        = CPTAxisLabelingPolicyAutomatic;
    x.axisLineStyle         = axisLineStyle;
    x.majorTickLineStyle    = axisLineStyle;
    x.labelTextStyle        = axisTitleTextStyle;
    //x.majorGridLineStyle    = majorGridLineStyle;
    //x.minorGridLineStyle    = minorGridLineStyle;
    x.axisLineStyle         = axisLineStyle;
    x.labelFormatter        = axisFormatter;
    x.majorTickLength       = majorTickLength;
    x.minorTickLength       = minorTickLength;
    x.title                 = @"Time Interval (Numbers of Day)";
    x.titleTextStyle        = axisTitleTextStyle;
    x.titleOffset           = self.titleSize;
    x.axisConstraints       = [CPTConstraints constraintWithLowerOffset:0.0];
    x.delegate              = self;
    
    // Label y with an automatic labeling policy.
    axisLineStyle.lineColor = [CPTColor greenColor];
    
    CPTXYAxis *y = axisSet.yAxis;
    y.labelingPolicy        = CPTAxisLabelingPolicyEqualDivisions;
    y.separateLayers        = YES;
    y.minorTicksPerInterval = 10;
    y.tickDirection         = CPTSignNegative;
    y.axisLineStyle         = axisLineStyle;
    y.majorTickLength       = majorTickLength;
    y.majorTickLineStyle    = axisLineStyle;
    //y.majorGridLineStyle    = majorGridLineStyle;
    y.minorTickLength       = minorTickLength;
    //y.minorGridLineStyle    = minorGridLineStyle;
    y.labelFormatter        = axisFormatter;
    y.labelTextStyle        = axisTitleTextStyle;
    y.title                 = @"BMI";
    y.titleTextStyle        = axisTitleTextStyle;
    y.titleOffset           = self.titleSize;
    y.delegate              = self;
    
    //    CPTFill *bandFill = [CPTFill fillWithColor:[[CPTColor darkGrayColor] colorWithAlphaComponent:0.5]];
    //    [y addBackgroundLimitBand:[CPTLimitBand limitBandWithRange:[CPTPlotRange plotRangeWithLocation:@7.0 length:@1.5] fill:bandFill]];
    //    [y addBackgroundLimitBand:[CPTLimitBand limitBandWithRange:[CPTPlotRange plotRangeWithLocation:@1.5 length:@3.0] fill:bandFill]];
    
    // Label y2 with an equal division labeling policy.
    axisLineStyle.lineColor = [CPTColor orangeColor];
    
    CPTXYAxis *y2 = [[CPTXYAxis alloc] init];
    y2.coordinate                  = CPTCoordinateY;
    y2.plotSpace                   = plotSpace;
    y2.orthogonalPosition          = @(20);
    y2.labelingPolicy              = CPTAxisLabelingPolicyEqualDivisions;
    y2.separateLayers              = NO;
    y2.preferredNumberOfMajorTicks = 5;
    y2.minorTicksPerInterval       = 10;
    y2.tickDirection               = CPTSignNone;
    y2.tickLabelDirection          = CPTSignPositive;
    y2.labelTextStyle              = axisTitleTextStyle;
    y2.axisLineStyle               = axisLineStyle;
    y2.majorTickLength             = majorTickLength;
    y2.majorTickLineStyle          = axisLineStyle;
    y2.minorTickLength             = minorTickLength;
    y2.labelFormatter              = axisFormatter;
    y2.title                       = @"Y2 Axis";
    y2.titleTextStyle              = axisTitleTextStyle;
    y2.titleOffset                 = self.titleSize * CPTFloat(-2.1);
    y2.delegate                    = self;
    
    // Add the y2 axis to the axis set
    self.graph.axisSet.axes = @[x, y];
    
}

- (void)reloadData{
    [self.graph reloadData];
    //self.isSMAShowed = self.isSMAShowed == YES ? NO : YES;
}

#pragma mark - Data processing function
- (NSUInteger)numberOfRecordsForPlot:(CPTPlot *)plot
{
    if ([plot.identifier isEqual:BASIC_PLOT]) {
        return self.xdata.count;
    }
    if ([plot.identifier isEqual:SMA_PLOT]) {
        return self.xdataSMA.count;
    }
    return 0;
}
// X and Y coordinate
- (NSNumber *)numberForPlot:(CPTPlot *)plot field:(NSUInteger)fieldEnum recordIndex:(NSUInteger)index
{
    if ( [plot isKindOfClass:[CPTScatterPlot class]] ) {
        if ([plot.identifier isEqual:BASIC_PLOT]) {
            switch (fieldEnum)
            {
                case CPTScatterPlotFieldX:
                    return self.xdata[index];
                    break;
                case CPTScatterPlotFieldY:
                    return self.ydata[index];
                    break;
                default:
                    break;
            }
        }
        if ([plot.identifier isEqual:SMA_PLOT]) {
            switch (fieldEnum)
            {
                case CPTScatterPlotFieldX:
                    return self.xdataSMA[index];
                    break;
                case CPTScatterPlotFieldY:
                    return self.ydataSMA[index];
                    break;
                default:
                    break;
            }
        }
    }
    return 0;
}

// Symbol for each point
- (CPTPlotSymbol *)symbolForScatterPlot:(CPTScatterPlot *)aPlot recordIndex:(NSUInteger)index
{
    CPTPlotSymbol *plotSymbol = [CPTPlotSymbol ellipsePlotSymbol];
    //    [plotSymbol setAnchorPoint:CGPointMake(0.5, 0.1)];
    [plotSymbol setSize:CGSizeMake(4, 4)];
    [plotSymbol setFill:[CPTFill fillWithColor:[CPTColor clearColor]]];
    plotSymbol.usesEvenOddClipRule = YES;
    CPTMutableLineStyle *lineStyle = [CPTMutableLineStyle lineStyle];
    lineStyle.lineWidth = 1.0;
    lineStyle.lineColor = [CPTColor whiteColor];
    [plotSymbol setLineStyle:lineStyle];
    [aPlot setPlotSymbol:plotSymbol];
    if ([aPlot.identifier isEqual:SMA_PLOT]) {
        return [CPTPlotSymbol plotSymbol];;
    }
    return plotSymbol;
}

// Label contain value of X/Y for each opoint
- (CPTLayer *)dataLabelForPlot:(nonnull CPTPlot *)plot recordIndex:(NSUInteger)index
{
    static CPTMutableTextStyle *whiteText = nil;
    static dispatch_once_t onceToken      = 0;
    
    dispatch_once(&onceToken, ^{
        whiteText = [[CPTMutableTextStyle alloc] init];
        whiteText.color = [CPTColor whiteColor];
        whiteText.fontSize = 8.0;
    });
    
    CPTTextLayer *newLayer = nil;
    
    if ( [plot isKindOfClass:[CPTPieChart class]] ) {
        switch ( index ) {
            case 0:
                newLayer = (id)[NSNull null];
                break;
                
            default:
                newLayer = [[CPTTextLayer alloc] initWithText:[NSString stringWithFormat:@"%lu", (unsigned long)index] style:whiteText];
                break;
        }
    }
    else if ( [plot isKindOfClass:[CPTScatterPlot class]] ) {
        if ([plot.identifier isEqual:BASIC_PLOT]) {
            double dataLabel = [[self.ydata objectAtIndex:index] doubleValue];
            newLayer = [[CPTTextLayer alloc] initWithText:[NSString stringWithFormat:@"%0.1f", dataLabel] style:whiteText];
        }
        if ([plot.identifier isEqual:SMA_PLOT]) {
            return nil;
        }
    }
    
    return newLayer;
}

#pragma mark - Modified function

//- (void)setMinortickLocation:(NSMutableArray*)cptNumberArray{
//    CPTXYAxisSet* axisSet = (CPTXYAxisSet*) [self.graph axisSet];
//    CPTXYAxis *yAxis = [axisSet yAxis];
//}

- (void)setXRange:(NSDecimal)xRange andYRange:(NSDecimal)yRange withXMin:(NSDecimal)xMin andYMin:(NSDecimal)yMin {
    CPTXYPlotSpace *studentPlotSpace = (CPTXYPlotSpace *)[self.graph defaultPlotSpace];
    [studentPlotSpace setXRange:[CPTPlotRange plotRangeWithLocationDecimal:xMin lengthDecimal:xRange]];
    [studentPlotSpace setYRange:[CPTPlotRange plotRangeWithLocationDecimal:yMin lengthDecimal:yRange]];
}

- (void)setXRange:(NSDecimal)xRange andYRange:(NSDecimal)yRange{
    CPTXYPlotSpace *studentPlotSpace = (CPTXYPlotSpace *)[self.graph defaultPlotSpace];
    NSDecimal origin_X_RangeLocation = studentPlotSpace.xRange.locationDecimal;
    NSDecimal origin_Y_RangeLocation = studentPlotSpace.yRange.locationDecimal;
    [studentPlotSpace setXRange:[CPTPlotRange plotRangeWithLocationDecimal:origin_X_RangeLocation lengthDecimal:xRange]];
    [studentPlotSpace setYRange:[CPTPlotRange plotRangeWithLocationDecimal:origin_Y_RangeLocation lengthDecimal:yRange]];
}

- (void)setXMin:(NSDecimal)xMin andYMin:(NSDecimal)yMin {
    CPTXYPlotSpace *studentPlotSpace = (CPTXYPlotSpace *)[self.graph defaultPlotSpace];
    NSDecimal origin_X_RangeLength = studentPlotSpace.xRange.lengthDecimal;
    NSDecimal origin_Y_RangeLength = studentPlotSpace.yRange.lengthDecimal;
    [studentPlotSpace setXRange:[CPTPlotRange plotRangeWithLocationDecimal:xMin lengthDecimal:origin_X_RangeLength]];
    [studentPlotSpace setYRange:[CPTPlotRange plotRangeWithLocationDecimal:yMin lengthDecimal:origin_Y_RangeLength]];
}

- (void)addScatterPlot:(CPTScatterPlot*)newPlot withIdentifier:(NSString*)plotIdentifier lineColor:(CPTColor*)lineColor lineWith:(CGFloat)lineWidth andGradientFill:(CPTColor*)areaBeginColor endingColor:(CPTColor*)areaEndingColor {
    newPlot = [[CPTScatterPlot alloc] initWithFrame:[self.graph bounds]];
    [newPlot setIdentifier:plotIdentifier];
    [newPlot setDelegate:self];
    [newPlot setDataSource:self];
    
    CPTMutableLineStyle *mainPlotLineStyle = [[newPlot dataLineStyle] mutableCopy];
    if (lineColor) { [mainPlotLineStyle setLineColor:lineColor]; }
    if (lineWidth) { [mainPlotLineStyle setLineWidth:lineWidth]; }
    
    [newPlot setDataLineStyle:mainPlotLineStyle];
    
    if (areaBeginColor && areaEndingColor) {
        CPTGradient *areaGradient = [CPTGradient gradientWithBeginningColor:areaBeginColor endingColor:areaEndingColor];
        [areaGradient setAngle:-90.0f];
        CPTFill *areaGradientFill = [CPTFill fillWithGradient:areaGradient];
        [newPlot setAreaFill:areaGradientFill];
        [newPlot setAreaBaseValue:@(0)];
    }
    
    [self.graph addPlot:newPlot];
    [self.arrayPlotIdentifier addObject:plotIdentifier];
}

- (void)calculateSMAData{
    self.xdataSMA = [[NSMutableArray alloc]init];
    for (int i = 0; i < self.xdata.count; i++) {
        if (i < PERIOD - 1) {
            //[self.xdataSMA addObject:@0];
        } else {
            [self.xdataSMA addObject:[self.xdata objectAtIndex:i]];
            
        }
    }
    self.ydataSMA = [[NSMutableArray alloc]init];
    for (int i = 0; i < self.ydata.count; i++) {
        if (i < PERIOD - 1) {
            //[self.ydataSMA addObject:@0];
        } else {
            double total = 0;
            int index = i - (PERIOD - 1);
            int maxIndex = index + (PERIOD - 1);
            
            for (int j = index; j <= maxIndex ; j++) {
                double n1 = [[self.ydata objectAtIndex:j] doubleValue];
                total += n1;
                NSLog(@"index: %d",j);
            }
            
            double average = total / (double) PERIOD;
            NSLog(@"END Period ==> Average: %0.2f",average);
            [self.ydataSMA addObject:@(average)];
        }
    }
    
}

- (void)setData:(NSMutableArray*)allData withSubData:(NSMutableArray*)subData{
    
    NSSortDescriptor *sort = [[NSSortDescriptor alloc] initWithKey:@"dateRecord" ascending:YES];
    [allData sortUsingDescriptors: @[sort]];
    NSMutableArray *xArr = [[NSMutableArray alloc]init];
    NSDate* beginDate = [[NSUtils dateFromString:
                          [Validator getSafeString:((HealthItem*) [allData objectAtIndex:0]).dateRecord] withFormat:PHR_SERVER_DATE_TIME_FORMAT]dateByAddingTimeInterval:- 24 * 3600];;
    for (int i = 0;i<allData.count -1;i++){
        HealthItem* obj = (HealthItem*) [allData objectAtIndex:i];
        NSDate* date = [NSUtils dateFromString:[Validator getSafeString:obj.dateRecord] withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        NSTimeInterval diff = [date timeIntervalSinceDate:beginDate];
        [xArr addObject: @((double)diff / (24 * 3600))];
    }
    
    int max = [[NSString stringWithFormat:@"%0.0f",[[subData objectAtIndex:0] doubleValue]] doubleValue];
    for (int i = 0; i < subData.count - 1; i++){
        if (max < (int) [[NSString stringWithFormat:@"%0.0f",[[subData objectAtIndex:0] doubleValue]] doubleValue]) {
            max = (int) [[NSString stringWithFormat:@"%0.0f",[[subData objectAtIndex:0] doubleValue]] doubleValue];
        }
    }
    [self setXRange:CPTDecimalFromDouble([[xArr objectAtIndex:xArr.count - 1] doubleValue] + 1) andYRange:CPTDecimalFromDouble((double)max * 1.5)];
    
    self.xdata = xArr;
    self.ydata = subData;
}

#pragma mark - Customize Style Function
- (void)customizeSMAScatterPlot:(CPTColor*)color lineWith:(CGFloat)lineWidth andGradientFill:(CPTColor*)areaBeginColor endingColor:(CPTColor*)areaEndingColor
{
    CPTMutableLineStyle *mainPlotLineStyle = [[self.SMAScatterPlot dataLineStyle] mutableCopy];
    [mainPlotLineStyle setLineWidth:lineWidth];
    [mainPlotLineStyle setLineColor:color];
    
    CPTGradient *areaGradient = [CPTGradient gradientWithBeginningColor:areaBeginColor endingColor:areaEndingColor];
    [areaGradient setAngle:-90.0f];
    CPTFill *areaGradientFill = [CPTFill fillWithGradient:areaGradient];
    
    [self.SMAScatterPlot setDataLineStyle:mainPlotLineStyle];
    [self.SMAScatterPlot setAreaFill:areaGradientFill];
    [self.SMAScatterPlot setAreaBaseValue:@(0)];
}

#pragma mark - CorePlot Axis delegate
-(void)axis:(nonnull CPTAxis *)axis labelWasSelected:(nonnull CPTAxisLabel *)label
{
    NSLog(@"%@ label was selected at location %@", axis.title, label.tickLocation);
}


#pragma mark - Utilities
-(CGFloat)titleSize
{
    CGFloat size;
    
#if TARGET_IPHONE_SIMULATOR || TARGET_OS_IPHONE
    switch ( UI_USER_INTERFACE_IDIOM() ) {
        case UIUserInterfaceIdiomPad:
            size = 24.0;
            break;
            
        case UIUserInterfaceIdiomPhone:
            size = 16.0;
            break;
            
        default:
            size = 12.0;
            break;
    }
#else
    size = 24.0;
#endif
    
    return size;
}



@end

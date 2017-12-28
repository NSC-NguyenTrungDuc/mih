package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.service.ihis.handler.xrts.XRT0000Q00GetModalityCodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0000Q00InitializeHandler;
import nta.med.service.ihis.handler.xrts.XRT0000Q00LayPacsInfoHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00FbxDataValidatingHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00GrdRadioListHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00GrdXRTHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00LayDupHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00MakeFindWorkerHandler;
import nta.med.service.ihis.handler.xrts.XRT0001U00SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U00GrdDcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U00GrdMcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U00LayDupDHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U00LayDupMHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U00SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U01GrdDcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U01GrdMcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U01LayDupDHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U01LayDupMHandler;
import nta.med.service.ihis.handler.xrts.XRT0101U01SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0122U00GrdDcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0122U00GrdMcodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0122U00LayDupDHandler;
import nta.med.service.ihis.handler.xrts.XRT0122U00LayDupMHandler;
import nta.med.service.ihis.handler.xrts.XRT0122U00SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0123U00GrdDCodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0123U00LayDupDHandler;
import nta.med.service.ihis.handler.xrts.XRT0123U00SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0123U00XEditGridCell3Handler;
import nta.med.service.ihis.handler.xrts.XRT0123U00grdMCodeHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00CheckNaewonYnHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00DataSendYnHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00FwkActorHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00FwkOrdDanuiHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00FwkOrdDanuiNameHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00GrdJaeryoColumnChangedHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00GrdOrderHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00GrdOrderRowFocusChangedHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00GrdPaListHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00GrdRadioListHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00LayConstantHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00LayPacsHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00LoadScreenHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00MentHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00NaewonDateHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00OcsCommonHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00RadioSaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00SaveLayoutHandler;
import nta.med.service.ihis.handler.xrts.XRT0201U00ToolTipHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00BtnDeleteClickHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00DsvBuhaGubunHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00DsvLDOCS0801Handler;
import nta.med.service.ihis.handler.xrts.XRT1002U00DsvRequestDataHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00DsvSideEffectHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00DsvXrayGubunHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00GrdComment1Handler;
import nta.med.service.ihis.handler.xrts.XRT1002U00GrdComment2Handler;
import nta.med.service.ihis.handler.xrts.XRT1002U00GrdComment3Handler;
import nta.med.service.ihis.handler.xrts.XRT1002U00GrdPaStatusHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00GrdXrayMethodHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayCPLHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayOrderByJundalPartHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayOrderDateHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayPrintDateHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayPrintOrderHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00LayXRT0123Handler;
import nta.med.service.ihis.handler.xrts.XRT1002U00PrintOrderByJudalPartHandler;
import nta.med.service.ihis.handler.xrts.XRT1002U00UpdateHandler;
import nta.med.service.ihis.handler.xrts.XRT7001Q01LayRadioHistoryHandler;
import nta.med.service.ihis.handler.xrts.XRT9001R01Lay9001RHandler;
import nta.med.service.ihis.handler.xrts.XRT9001R03Lay9003RHandler;
import nta.med.service.ihis.handler.xrts.XRT9001R05lay9005RHandler;
import nta.med.service.ihis.handler.xrts.XRT9001R06lay9006RHandler;
import nta.med.service.ihis.handler.xrts.Xrt0122Q00GrdDCodeHandler;
import nta.med.service.ihis.handler.xrts.Xrt0122Q00GrdMCodeHandler;
import nta.med.service.ihis.handler.xrts.Xrt0122Q00LayCodeNameHandler;
import nta.med.service.ihis.handler.xrts.Xrt0122Q00LayDupDHandler;
import nta.med.service.ihis.handler.xrts.Xrt0122Q00LayDupMHandler;
import nta.med.service.ihis.proto.XrtsServiceProto;

public class XrtsVerticle extends AbstractVerticle {


	public XrtsVerticle() {
		super(XrtsServiceProto.class, XrtsServiceProto.getDescriptor());
	}

	@Override
	protected void doStart() throws Exception {
		// --- [START] XRT0000Q00 ---
		registerHandler(XrtsServiceProto.XRT0000Q00GetModalityCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0000Q00GetModalityCodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0000Q00InitializeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0000Q00InitializeHandler.class));
		registerHandler(XrtsServiceProto.XRT0000Q00LayPacsInfoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0000Q00LayPacsInfoHandler.class));
		// --- [END] XRT0000Q00 ---
		// --- [START] XRT7001Q01 ---
		registerHandler(XrtsServiceProto.XRT7001Q01LayRadioHistoryRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT7001Q01LayRadioHistoryHandler.class));
		//-----[END] XRT7001Q01------------

		//------[START] XRT9001R01-------------
		registerHandler(XrtsServiceProto.XRT9001R01Lay9001RRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT9001R01Lay9001RHandler.class));
		//------[END] XRT9001R01---------------

		//------[START] XRT9001R03-------------
		registerHandler(XrtsServiceProto.XRT9001R03Lay9003RRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT9001R03Lay9003RHandler.class));
		//------[END] XRT9001R03---------------

		//------[START] XRT0101U00--------------
		registerHandler(XrtsServiceProto.XRT0101U00GrdMcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U00GrdMcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U00GrdDcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U00GrdDcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U00LayDupDHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U00LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U00LayDupMHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U00SaveLayoutHandler.class));

		//------[END] XRT0101U00 ---------------

		//------[START] XRT0001U00------------------
		//new define
		registerHandler(XrtsServiceProto.XRT0001U00GrdRadioListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00GrdRadioListHandler.class));
		registerHandler(XrtsServiceProto.XRT0001U00GrdXRTRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00GrdXRTHandler.class));
		registerHandler(XrtsServiceProto.XRT0001U00LayDupRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00LayDupHandler.class));
		registerHandler(XrtsServiceProto.XRT0001U00FbxDataValidatingRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00FbxDataValidatingHandler.class));
		registerHandler(XrtsServiceProto.XRT0001U00MakeFindWorkerRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00MakeFindWorkerHandler.class));
		registerHandler(XrtsServiceProto.XRT0001U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0001U00SaveLayoutHandler.class));

		//------[END] XRT0001U00-------------------

		//------[START] [XRT0123U00]-Register radiation's condition
		//re define
		registerHandler(XrtsServiceProto.XRT0123U00GrdDCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0123U00GrdDCodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0123U00grdMCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0123U00grdMCodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0123U00XEditGridCell3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0123U00XEditGridCell3Handler.class));
		registerHandler(XrtsServiceProto.XRT0123U00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0123U00LayDupDHandler.class));
		registerHandler(XrtsServiceProto.XRT0123U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0123U00SaveLayoutHandler.class));
		//------[END] [XRT0123U00]-Register radiation's condition

		//-----[START] [XRT0122U00]-Manage radiation's position ------------
		//re define
		registerHandler(XrtsServiceProto.XRT0122U00GrdMcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0122U00GrdMcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0122U00GrdDcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0122U00GrdDcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0122U00LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0122U00LayDupMHandler.class));
		registerHandler(XrtsServiceProto.XRT0122U00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0122U00LayDupDHandler.class));
		registerHandler(XrtsServiceProto.XRT0122U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0122U00SaveLayoutHandler.class));

		//-----[END] [XRT0122U00]-Manage radiation's position
		//-----[START] [XRT0201U00]- Manage radiation order
		registerHandler(XrtsServiceProto.XRT0201U00LoadScreenRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00LoadScreenHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00GrdPaListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00GrdPaListHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00GrdOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00GrdOrderHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00GrdOrderRowFocusChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00GrdOrderRowFocusChangedHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00LayPacsRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00LayPacsHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00DataSendYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00DataSendYnHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00FwkOrdDanuiRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00FwkOrdDanuiHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00FwkOrdDanuiNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00FwkOrdDanuiNameHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00NaewonDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00NaewonDateHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00MentRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00MentHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00GrdJaeryoColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00GrdJaeryoColumnChangedHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00FwkActorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00FwkActorHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00OcsCommonRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00OcsCommonHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00CheckNaewonYnRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00CheckNaewonYnHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00GrdRadioListRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00GrdRadioListHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00RadioSaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00RadioSaveLayoutHandler.class));

		registerHandler(XrtsServiceProto.XRT0201U00LayConstantRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00LayConstantHandler.class));
		registerHandler(XrtsServiceProto.XRT0201U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00SaveLayoutHandler.class));

		//-----[END] [XRT0201U00]- Manage radiation order

		//-----[START] [XRT1002U00]
		registerHandler(XrtsServiceProto.XRT1002U00DsvLDOCS0801Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00DsvLDOCS0801Handler.class));
		registerHandler(XrtsServiceProto.XRT1002U00DsvRequestDataRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00DsvRequestDataHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00DsvSideEffectRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00DsvSideEffectHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00GrdComment3Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00GrdComment3Handler.class));
		registerHandler(XrtsServiceProto.XRT1002U00GrdPaStatusRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00GrdPaStatusHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayCPLRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayCPLHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayOrderByJundalPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayOrderByJundalPartHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayOrderDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayOrderDateHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayPrintDateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayPrintDateHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayPrintOrderRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayPrintOrderHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00LayXRT0123Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00LayXRT0123Handler.class));
		registerHandler(XrtsServiceProto.XRT1002U00BtnDeleteClickRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00BtnDeleteClickHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00PrintOrderByJudalPartRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00PrintOrderByJudalPartHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00UpdateRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00UpdateHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00GrdComment2Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00GrdComment2Handler.class));
		registerHandler(XrtsServiceProto.XRT1002U00GrdComment1Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00GrdComment1Handler.class));
		registerHandler(XrtsServiceProto.XRT1002U00GrdXrayMethodRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00GrdXrayMethodHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00DsvBuhaGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00DsvBuhaGubunHandler.class));
		registerHandler(XrtsServiceProto.XRT1002U00DsvXrayGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT1002U00DsvXrayGubunHandler.class));

		//-----[END] [XRT1002U00]

		//-----[START] [XRT0101U01]
		registerHandler(XrtsServiceProto.XRT0101U01LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U01LayDupMHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U01SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U01SaveLayoutHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U01GrdDcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U01GrdDcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U01GrdMcodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U01GrdMcodeHandler.class));
		registerHandler(XrtsServiceProto.XRT0101U01LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0101U01LayDupDHandler.class));
		//-----[END] [XRT0101U01]

		//-----[START] [XRT0122Q00]
		registerHandler(XrtsServiceProto.Xrt0122Q00GrdDCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00GrdDCodeHandler.class));
		registerHandler(XrtsServiceProto.Xrt0122Q00LayDupDRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00LayDupDHandler.class));
		registerHandler(XrtsServiceProto.Xrt0122Q00GrdMCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00GrdMCodeHandler.class));
		registerHandler(XrtsServiceProto.Xrt0122Q00LayDupMRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00LayDupMHandler.class));
		registerHandler(XrtsServiceProto.Xrt0122Q00LayCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(Xrt0122Q00LayCodeNameHandler.class));
		//-----[END] [XRT0122Q00]
		
		//-----[START] [XRT0201U00]
		registerHandler(XrtsServiceProto.XRT0201U00ToolTipRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT0201U00ToolTipHandler.class));
		//-----[END] [XRT0201U00]
		registerHandler(XrtsServiceProto.XRT9001R06lay9006RRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT9001R06lay9006RHandler.class));
		registerHandler(XrtsServiceProto.XRT9001R05lay9005RRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(XRT9001R05lay9005RHandler.class));
	}

	@Override
	protected void doStop() throws Exception {

	}
}

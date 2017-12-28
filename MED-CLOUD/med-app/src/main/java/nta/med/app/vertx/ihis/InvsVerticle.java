package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.invs.*;
import nta.med.service.ihis.proto.InvsServiceProto;

/**
 * @author DEV-OaiDV
 */
public class InvsVerticle extends AbstractVerticle {

    public InvsVerticle() {
        super(InvsServiceProto.class, InvsServiceProto.getDescriptor());
    }
    @Override
    protected void doStart() throws Exception {
    	//[START] INV4001U00
    	registerHandler(InvsServiceProto.INV4001U00LoadCodeNameRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00LoadCodeNameHandler.class));
    	registerHandler(InvsServiceProto.INV4001U00DrugUserRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00DrugUserHandler.class));
    	registerHandler(InvsServiceProto.INV4001U00Grd4002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00Grd4002Handler.class));
    	registerHandler(InvsServiceProto.INV4001U00Grd4001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00Grd4001Handler.class));
    	registerHandler(InvsServiceProto.INV4001LoadBuseoRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001LoadBuseoHandler.class));
    	registerHandler(InvsServiceProto.INV4001NextSeqRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001NextSeqHandler.class));
    	registerHandler(InvsServiceProto.INV4001SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001SaveLayoutHandler.class));
    	registerHandler(InvsServiceProto.INV4001U00ExportCSVRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00ExportCSVHandler.class));
    	registerHandler(InvsServiceProto.INV4001U00Grd4001GenImportCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV4001U00Grd4001GenImportCodeHandler.class));
    	//[END] INV4001U00
    	
    	//[START] INV6000U00
    	registerHandler(InvsServiceProto.INV6000U00LayINV6000Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00LayINV6000Handler.class));
    	registerHandler(InvsServiceProto.INV6000U00GrdINV6001Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00GrdINV6001Handler.class));
    	registerHandler(InvsServiceProto.INV6000U00LaySummaryDetailRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00LaySummaryDetailHandler.class));
    	registerHandler(InvsServiceProto.INV6000U00LaySummaryMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00LaySummaryMasterHandler.class));
    	registerHandler(InvsServiceProto.INV6000U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00SaveLayoutHandler.class));
    	registerHandler(InvsServiceProto.INV6000U00ExportCSVRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6000U00ExportCSVHandler.class));
    	//[END] INV6000U00
    	
    	//[START] INV6002
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002LoadCbxJaeryoGubunRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002LoadCbxJaeryoGubunHandler.class));
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002LoadcbxActorRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002LoadcbxActorHandler.class));
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002Handler.class));
    	//[END] INV6002
    	
    	//[START] INV0101U01
    	
    	registerHandler(InvsServiceProto.INV0101U01GridDetailRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV0101U01GridDetailHandler.class));
    	registerHandler(InvsServiceProto.INV0101U01GridMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV0101U01GridMasterHandler.class));
    	registerHandler(InvsServiceProto.CheckData0101U01Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckData0101U01Handler.class));
    	registerHandler(InvsServiceProto.SaveLayoutINV0101U01Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SaveLayoutINV0101U01Handler.class));
    	registerHandler(InvsServiceProto.INV0101U01LoadComboRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV0101U01LoadComboHandler.class));
    	
    	//[END] INV0101U01
    	
    	registerHandler(InvsServiceProto.INV2003U00GrdINV2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00GrdINV2003Handler.class));
    	registerHandler(InvsServiceProto.INV2003U00GrdINV2004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00GrdINV2004Handler.class));
//		registerHandler(InvsServiceProto.INV2003U00SaveINV2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00SaveINV2003Handler.class));
//		registerHandler(InvsServiceProto.INV2003U00saveINV2004Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00SaveINV2004Handler.class));
		registerHandler(InvsServiceProto.INV2003U00SaveLayoutRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00SaveLayoutHandler.class));
		registerHandler(InvsServiceProto.INV2003U00GetCbxChulgoTypeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00GetCbxChulgoTypeHandler.class));
		registerHandler(InvsServiceProto.GetPkINV2003Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(GetPkINV2003Handler.class));
		registerHandler(InvsServiceProto.INV2003U00ExportCSVRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV2003U00ExportCSVHandler.class));
		
    	//[START] INV0101U00
    	registerHandler(InvsServiceProto.LoadGrdMasterINV0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadGrdMasterINV0101Handler.class));
    	registerHandler(InvsServiceProto.LoadGrdDetailINV0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadGrdDetailINV0101Handler.class));
    	registerHandler(InvsServiceProto.LoadComboINV0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadComboINV0101Handler.class));
    	registerHandler(InvsServiceProto.SaveLayoutINV0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(SaveLayoutINV0101Handler.class));
    	registerHandler(InvsServiceProto.CheckDuplicateDataINV0101Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(CheckDuplicateDataINV0101Handler.class));
    	//[END] INV0101U00
    	
    	//[START] INV6002U00
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002BeforeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002BeforeHandler.class));
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002AfterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002AfterHandler.class));
    	registerHandler(InvsServiceProto.INV6002U00GrdINV6002ExcuteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(INV6002U00GrdINV6002ExcuteHandler.class));
    	//[END] INV6002U00
    	
    	//[START] INV0110Q00
    	registerHandler(InvsServiceProto.LoadINV0110Q00Request.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(LoadINV0110Q00Handler.class));
    	//[END] INV0110Q00
    	
    }

    @Override
    protected void doStop() throws Exception {
    	
    }
}

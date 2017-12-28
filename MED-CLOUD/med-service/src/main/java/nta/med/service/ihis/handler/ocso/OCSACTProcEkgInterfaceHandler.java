package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.pfe.Pfe0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTProcEkgInterfaceHandler extends ScreenHandler<OcsoServiceProto.OCSACTProcEkgInterfaceRequest, OcsoServiceProto.OCSACTProcEkgInterfaceResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTProcEkgInterfaceHandler.class);                                    
	@Resource                                                                                                       
	private Pfe0201Repository pfe0201Repository;                                                                    
	@Override
	public boolean isValid(OcsoServiceProto.OCSACTProcEkgInterfaceRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional
	public OcsoServiceProto.OCSACTProcEkgInterfaceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTProcEkgInterfaceRequest request) throws Exception {
		OcsoServiceProto.OCSACTProcEkgInterfaceResponse.Builder response = OcsoServiceProto.OCSACTProcEkgInterfaceResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		//call procedure
    	Double pkdrg5010= pfe0201Repository.callPrPfeEkgPfe5010Insert(hospCode, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), 
    			"0", "O", request.getBunho(), CommonUtils.parseInteger(request.getFkout1001()));
    	//Throw exception if fail
    	if(pkdrg5010 == null || pkdrg5010.equals(new Double(-1))){
    		response.setExceptionId("1");
    		throw new ExecutionException(response.build());
        } else {
        	response.setPkpfe5010(pkdrg5010.toString());
        	// update
        	Integer updatePfe0201 = pfe0201Repository.updateOCSACTWhereHospCodeFkocs1003(pkdrg5010, hospCode,  CommonUtils.parseDouble(request.getPkocs()));
        	if (updatePfe0201 == null || updatePfe0201 < 1) {
        		response.setExceptionId("2");
        		throw new ExecutionException(response.build());
        	}
        	//2. Get rtnIfsCnt
        	String oErr = pfe0201Repository.callPrPfeEkgIfsProc(hospCode, request.getIoGubun(), pkdrg5010.intValue(), request.getUserId());
        	if (!StringUtils.isEmpty(oErr) || "1".equals(oErr)){
        		response.setExceptionId("3");
        		throw new ExecutionException(response.build());
        	} else {
        		response.setRtnIfsCnt(oErr);
        	}
        }
		return response.build();
	}                                                                                                                 
}
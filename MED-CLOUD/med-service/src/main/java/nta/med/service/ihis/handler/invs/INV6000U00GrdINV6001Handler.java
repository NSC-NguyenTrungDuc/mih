package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inv.Inv6000Repository;
import nta.med.data.model.ihis.invs.INV6000U00GrdINV6001Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class INV6000U00GrdINV6001Handler extends ScreenHandler<InvsServiceProto.INV6000U00GrdINV6001Request, InvsServiceProto.INV6000U00GrdINV6001Response>  {
	
	@Resource
	private Inv6000Repository inv6000Repository;
	
    @Override
    @Transactional(readOnly = true)
    public InvsServiceProto.INV6000U00GrdINV6001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
    		InvsServiceProto.INV6000U00GrdINV6001Request request) throws Exception {
    	InvsServiceProto.INV6000U00GrdINV6001Response.Builder response = InvsServiceProto.INV6000U00GrdINV6001Response.newBuilder();
    	String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		//Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String difference = StringUtils.isEmpty(request.getDifference()) == true ? "%" : request.getDifference().trim();
		
    	List<INV6000U00GrdINV6001Info> grdInv6001s  = inv6000Repository.getINV6000U00GrdINV6001Info(getHospitalCode(vertx, sessionId), 
    			 getLanguage(vertx, sessionId), CommonUtils.parseDouble(request.getFkinv6000()), request.getJaeryoCode(), request.getPageNumber().trim(), offset, difference);
    	 if(!CollectionUtils.isEmpty(grdInv6001s)){
    		 for(INV6000U00GrdINV6001Info item : grdInv6001s){
    			 InvsModelProto.INV6000U00GrdINV6001Info.Builder info = InvsModelProto.INV6000U00GrdINV6001Info.newBuilder();
    			 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                 response.addGrdInv6001(info);
    		 }
    	 }
        return response.build();
    }
}

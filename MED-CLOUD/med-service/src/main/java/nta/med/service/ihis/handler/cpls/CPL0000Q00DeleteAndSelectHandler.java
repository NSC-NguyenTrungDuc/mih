package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.CpltempRepository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.cpls.CPL0000Q00SelectOUT0101ListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00DeleteAndSelectRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00DeleteAndSelectResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL0000Q00DeleteAndSelectHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00DeleteAndSelectRequest, CplsServiceProto.CPL0000Q00DeleteAndSelectResponse> {
private static final Log LOG = LogFactory.getLog(CPL0000Q00DeleteAndSelectHandler.class);
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private CpltempRepository cpltempRepository;
	
	@Override
	public CPL0000Q00DeleteAndSelectResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0000Q00DeleteAndSelectRequest request) throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
        CplsServiceProto.CPL0000Q00DeleteAndSelectResponse.Builder response = CplsServiceProto.CPL0000Q00DeleteAndSelectResponse .newBuilder();
    	if(cpltempRepository.deleteCpltempCPL0000Q00(hospitalCode, request.getUserId())>0){
    		response.setDeleteResult(true);	
    	}else{
    		response.setDeleteResult(false);
    	}

    	List<CPL0000Q00SelectOUT0101ListItemInfo> listItem = out0101Repository.getCPL0000Q00SelectOUT0101ListItemInfo(hospitalCode, request.getBunho());
        if(!CollectionUtils.isEmpty(listItem)) {
        	for(CPL0000Q00SelectOUT0101ListItemInfo item : listItem) {
        		CplsModelProto.CPL0000Q00SelectOUT0101ListItemInfo.Builder info = CplsModelProto.CPL0000Q00SelectOUT0101ListItemInfo.newBuilder();
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (!StringUtils.isEmpty(item.getBirth())) {
        			info.setBirth(item.getBirth());
        		}
        		if (!StringUtils.isEmpty(item.getSex())) {
        			info.setSex(item.getSex());
        		}
        		if (item.getAge() != null) {
        			info.setAge(item.getAge().toString());
        		}

        		response.addSelectResult(info);
        	}
        }
		return response.build();
	}
}

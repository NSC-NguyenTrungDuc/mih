package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.nuro.NuroChkGetWonyoiYnInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroChkGetWonyoiYnHandler extends ScreenHandler<NuroServiceProto.NuroChkGetWonyoiYnRequest, NuroServiceProto.NuroChkGetWonyoiYnResponse> {
	private static final Log LOG = LogFactory.getLog(NuroChkGetWonyoiYnHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private CommonRepository commonRepository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroChkGetWonyoiYnResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroChkGetWonyoiYnRequest request) throws Exception {
		NuroServiceProto.NuroChkGetWonyoiYnResponse.Builder response = NuroServiceProto.NuroChkGetWonyoiYnResponse.newBuilder();
		String wonyoiYN = "Y"; 
        String wonyoiFlag = "1";
        String aWonyoiYn1;
        String aWonyoiYn2;
        String aWonyoiYn3;
        String aWonyoiYn4;
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<ComboListItemInfo> listItem = bas0102Repository.getComboListItemInfoByCodeType(hospCode, language, "WONYOI_CHK_FLAG");
        if(listItem != null && listItem.size() > 0){
        	wonyoiFlag = "0";
        }
        
        NuroChkGetWonyoiYnInfo info =  commonRepository.getNuroChkGetWonyoiYnInfo(hospCode, language, request.getGubun(),
        		request.getGongbiCode1(), request.getGongbiCode2(), request.getGongbiCode3(), request.getGongbiCode4());
        if(info != null){
        	aWonyoiYn1 = info.getWonyoiYn1();
        	aWonyoiYn2 = info.getWonyoiYn2();
        	aWonyoiYn3 = info.getWonyoiYn3();
        	aWonyoiYn4 = info.getWonyoiYn4();
        	if(wonyoiFlag.equals("1")){
        		if (aWonyoiYn1 == "N" || aWonyoiYn2 == "N" || aWonyoiYn3 == "N" || aWonyoiYn4 == "N")
                    wonyoiYN = "N";
            }else{
                if (aWonyoiYn1 == "Y" || aWonyoiYn2 == "Y" || aWonyoiYn3 == "Y" || aWonyoiYn4 == "Y")
                    wonyoiYN = "Y";                
            }
        }
        response.setWonyoiYn(wonyoiYN);
		return response.build();
	}

}

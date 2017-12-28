package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0123;
import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00ControlDataValidatingRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0001U00ControlDataValidatingResponse;

@Service
@Scope("prototype")
@Transactional(readOnly = true)
public class BAS0001U00ControlDataValidatingHandler extends ScreenHandler<BassServiceProto.BAS0001U00ControlDataValidatingRequest, BassServiceProto.BAS0001U00ControlDataValidatingResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(BAS0001U00ControlDataValidatingHandler.class);
	
	@Resource
	private Bas0123Repository bas0123Repository;

	@Override
	public BAS0001U00ControlDataValidatingResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0001U00ControlDataValidatingRequest request) throws Exception{
	
		BassServiceProto.BAS0001U00ControlDataValidatingResponse.Builder response = BassServiceProto.BAS0001U00ControlDataValidatingResponse.newBuilder();
		
		if(request.getCtlName().equals("txtZip_Code2")){
			String zipCode = request.getZipCode1().concat(request.getZipCode2());
			List<Bas0123> listItem =bas0123Repository.getBAS0001U00ControlDataValidating(zipCode);
			if (!CollectionUtils.isEmpty(listItem)) {
				String layCom=listItem.get(0).getZipName1().concat(listItem.get(0).getZipName2()).concat(listItem.get(0).getZipName3());
				if(!StringUtils.isEmpty(layCom)){
					response.setLayCom(layCom);
				}
			}
		}
		
        return response.build();
	}
	

}
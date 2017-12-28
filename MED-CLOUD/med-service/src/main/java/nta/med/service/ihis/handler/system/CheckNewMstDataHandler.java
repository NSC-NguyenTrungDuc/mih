package nta.med.service.ihis.handler.system;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.ScreenMater;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.CheckNewMstDataRequest;
import nta.med.service.ihis.proto.SystemServiceProto.CheckNewMstDataResponse;

@Service
@Scope("prototype")
public class CheckNewMstDataHandler extends ScreenHandler<SystemServiceProto.CheckNewMstDataRequest, SystemServiceProto.CheckNewMstDataResponse>{
	private static final Log logger = LogFactory.getLog(CheckNewMstDataHandler.class);
	@Resource
	private Bas0001Repository bas0001Repository;

    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
        return true;
    }

	@Override
	@Transactional(readOnly = true)
	public CheckNewMstDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CheckNewMstDataRequest request) throws Exception {
		SystemServiceProto.CheckNewMstDataResponse.Builder response = SystemServiceProto.CheckNewMstDataResponse.newBuilder();
		Bas0001 basNTA = bas0001Repository.findLatestByHospCode("NTA").get(0);
        Bas0001 basClinic = bas0001Repository.findLatestByHospCode(getHospitalCode(vertx, sessionId)).get(0);

        String nta = basNTA.getRevision();
        String clinic = basClinic.getRevision();
        String[] ntas = nta.split("\\|");
        String[] clinics = clinic.split("\\|");

        Map<String, Long> mapNtas = new HashMap<>();
        for (String item1 : ntas) {
              String[] items = item1.split("_");
              mapNtas.put(items[0], Long.parseLong(items[1]));
        }
        Map<String, Long> mapClinic = new HashMap<>();
        if(!StringUtils.isEmpty(clinic)){
        	for (String item2 : clinics) {
                String[] items = item2.split("_");
                mapClinic.put(items[0], Long.parseLong(items[1]));
            }
        }
        List<String> tableList = new ArrayList<>();
        for (Map.Entry<String, Long> entry : mapNtas.entrySet())
        {
            if(mapClinic.containsKey(entry.getKey()))
            {
                Long keyClinic  = mapClinic.get(entry.getKey());
                if(keyClinic < entry.getValue())
                {
                    tableList.add(entry.getKey());
                }
            }
        }

        List<SystemModelProto.NewMstDataListInfo> masterDataList = new ArrayList<>();

        for(ScreenMater screenMater : ScreenMater.values())
        {
            boolean hasContainTable = false;
            SystemModelProto.NewMstDataListInfo.Builder masterInfo =  SystemModelProto.NewMstDataListInfo.newBuilder();

            for(String screen : tableList)
            {
                if(screenMater.getTables().contains(screen))
                {
                    hasContainTable = true;
                    break;
                }
            }

            if(hasContainTable)
            {
                masterInfo.setScreenName(screenMater.name());
                masterDataList.add(masterInfo.build());
            }
        }
        response.addAllListData(masterDataList);
		return response.build();
	}

}

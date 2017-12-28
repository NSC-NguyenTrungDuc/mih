package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.ScreenTable;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateMasterDataRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class UpdateMasterDataHandler extends ScreenHandler<UpdateMasterDataRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(UpdateMasterDataHandler.class);
    @Autowired
    Bas0310Repository bas0310Repository;
    @Resource
	private Cpl0101Repository cpl0101Repository;
    @Autowired
    Ocs0103Repository ocs0103Repository;
    @Autowired
    Bas0001Repository bas0001Repository;
    @Autowired
    Cht0110Repository cht0110Repository;
    
    @Override
    @Route(global = false)
    public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
                                 UpdateMasterDataRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String errorFlg = "z";
        String hospCode = getHospitalCode(vertx, sessionId);
        String screenTable = "";
        if (request.getScreenName().equals("OCS0103U00")) {
            //call procedure PR_OCS0103U00_UPDATE_MASTER_DATA
        	errorFlg = ocs0103Repository.callPrOcs0103U00UpdateMaster(hospCode);
        	screenTable = ScreenTable.OCS0103U00.getValue();
        } else if (request.getScreenName().equals("BAS0310U00")) {
            //call procedure PR_BAS0310U00_UPDATE_MASTER_DATA
            errorFlg = bas0310Repository.callPrUpdateMasterData(hospCode);
            screenTable = ScreenTable.BAS0310U00.getValue();
        } else if (request.getScreenName().equals("CPL0101U00")) {
            //call procedure PR_CPL0101U00_UPDATE_MASTER_DATA
        	errorFlg = cpl0101Repository.callPrCpl0101U00UpdateMasterData(hospCode);
        	screenTable = ScreenTable.CPL0101U00.getValue();
        }else if(request.getScreenName().equals("CHT0110U00")){
        	 //call procedure PR_CHT0110U00_UPDATE_MASTER_DATA
        	errorFlg = cht0110Repository.callPrCht0110U00UpdateMasterData(hospCode);
        	screenTable = ScreenTable.CHT0110U00.getValue();
        }
        
        if (!"0".equalsIgnoreCase(errorFlg)) {
        	LOGGER.error("fail to merge master data, ScreenName = " + request.getScreenName());
            response.setResult(false);
            response.setMsg(errorFlg);
            throw new ExecutionException(response.build());
        }
//      //update revision
//      	List<Bas0001> globalTable =  bas0001Repository.findLatestByHospCode("NTA");
//      	List<Bas0001> shardingTable = bas0001Repository.findLatestByHospCode(hospCode);
//      		if(!CollectionUtils.isEmpty(globalTable) && !CollectionUtils.isEmpty(shardingTable)){
//      			String globalRev = globalTable.get(0).getRevision();
//      			String shardingRev = shardingTable.get(0).getRevision();
//      			String newShardingRev = CommonUtils.getNewShardingRevision(globalRev, shardingRev, screenTable);
//      			Bas0001 bas0001 = shardingTable.get(0);
//      			bas0001.setRevision(newShardingRev);
//      			bas0001Repository.save(bas0001);
//      			
//      		}
        response.setResult(true);
        return response.build();
    }
    
    @Override
    @Route(global = true)
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		UpdateMasterDataRequest request, UpdateResponse rs) throws Exception {
    	SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
    	if(rs.getResult()){
    		String hospCode = getHospitalCode(vertx, sessionId);
    		String screenTable = "";
    		if (request.getScreenName().equals("OCS0103U00")) {
    			screenTable = ScreenTable.OCS0103U00.getValue();
    		} else if (request.getScreenName().equals("BAS0310U00")) {
    			screenTable = ScreenTable.BAS0310U00.getValue();
    		} else if (request.getScreenName().equals("CPL0101U00")) {
    			screenTable = ScreenTable.CPL0101U00.getValue();
    		}else if(request.getScreenName().equals("CHT0110U00")){
    			screenTable = ScreenTable.CHT0110U00.getValue();
    		}
    		//update revision
    		List<Bas0001> globalTable =  bas0001Repository.findLatestByHospCode("NTA");
    		List<Bas0001> shardingTable = bas0001Repository.findLatestByHospCode(hospCode);
    		if(!CollectionUtils.isEmpty(globalTable) && !CollectionUtils.isEmpty(shardingTable)){
    			String globalRev = globalTable.get(0).getRevision();
    			String shardingRev = shardingTable.get(0).getRevision();
    			String newShardingRev = CommonUtils.getNewShardingRevision(globalRev, shardingRev, screenTable);
    			Bas0001 bas0001 = shardingTable.get(0);
    			bas0001.setRevision(newShardingRev);
    			bas0001Repository.save(bas0001);
    			
    		}
    		response.setResult(true);
    		return response.build();
    	}
    	return rs;
    }
}

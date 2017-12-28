package nta.med.service.integration.bass;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

/**
 * @author DEV-HuanLT
 */
public class BAS2015U00MasterDataHandlerTest extends MessageRequestTest {
	
    @Test
    public void test() throws InterruptedException {
    	BassServiceProto.BAS2015U00MasterDataRequest request = BassServiceProto.BAS2015U00MasterDataRequest
                .newBuilder()
//                .setKinkiType(CommonModelProto.KinkiType.KINKI_MSG)
//                .setKinkiType(CommonModelProto.KinkiType.KINKI_DIEASE)
//                .setKinkiType(CommonModelProto.KinkiType.DOSAGE)
                .setKinkiType(CommonModelProto.KinkiType.DRUG_CHECKING)
//                .setKinkiType(CommonModelProto.KinkiType.INTERATION)
//                .setKinkiType(CommonModelProto.KinkiType.GENERIC_NAME)
                .setActionType(CommonModelProto.ActionType.IMPORT)
                //.setUploadPath("info_all.zip")
                //.setUploadPath("Drug_Interaction.zip")
                .build();
    	
    	sentRequestToMedApp(request, BassServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}

